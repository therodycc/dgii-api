using Microsoft.EntityFrameworkCore;
using dgii_api;
using dgii_api.data;
using dgii_api.helpers;
using dgii_api.interfaces;
using dgii_api.Repository;
using dgii_api.Middlewares;
using dgii_api.Services;

const string CorsPolicy = "MyPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<RequestDelegate>(provider => provider.GetRequiredService<RequestDelegate>());
builder.Services.AddTransient<AuthMiddleware>();

builder.Services.AddScoped<IComprobanteFiscalRepository, ComprobanteFiscalRepository>();
builder.Services.AddScoped<IContribuyenteRepository, ContribuyenteRepository>();

builder.Services.AddScoped<IContribuyenteService, ContribuyenteService>();
builder.Services.AddScoped<IComprobanteFiscalService, ComprobanteFiscalService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy, builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    new SeedUtils().SeedData(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(CorsPolicy);

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
