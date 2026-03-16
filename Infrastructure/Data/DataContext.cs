using Microsoft.EntityFrameworkCore;
using dgii_api.models;

namespace dgii_api.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Contribuyente> Contribuyentes { get; set; }

        public DbSet<ComprobanteFiscal> ComprobantesFiscales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ComprobanteFiscal>()
                .HasOne(c => c.Contribuyente)
                .WithMany(c => c.ComprobantesFiscales)
                .HasForeignKey(c => c.ContribuyenteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contribuyente>()
                .HasIndex(c => c.RncCedula)
                .IsUnique();

            modelBuilder.Entity<ComprobanteFiscal>()
                .Property(c => c.Monto)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ComprobanteFiscal>()
                .Property(c => c.Itbis18)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ComprobanteFiscal>()
                .HasIndex(c => c.NCF)
                .IsUnique();
        }
    }
}