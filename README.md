## Versión

```bash
8.0.100
```

**_`Sql Server`_**

**`C# Net Core.`**

### SqlServer on Mac

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=MiC0ntr@s3ñ@' -p 1433:1433 --name sqlserver -v RUTA_LOCAL:/var/opt/mssql -d mcr.microsoft.com/mssql/server

# Conéctate al contenedor
docker exec -it sqlserver /bin/bash

# Conéctate a la instancia de SQL Server
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P MiC0ntr@s3ñ@

/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P MiC0ntr@s3ñ@ -Q 'EXEC sp_configure 'remote access', 1; RECONFIGURE;'
```

`***You can use a database administrator tool like dbeaver***`

![Dbeaver](https://repository-images.githubusercontent.com/44662669/f3f5c080-808b-11ea-9713-2bea65875d95)

## Secrets

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Data Source=localhost,1433;Initial Catalog=dgii_db;User ID=SA;Password=MiC0ntr@s3ñ@;TrustServerCertificate=True;"
```

## Instalation

```bash
dotnet ef database update;
dotnet run seeddata;
```

# Run

```bash
dotnet watch;
```


# Migrations

```bash
dotnet ef migrations remove; # Elimina las migraciones
dotnet ef migrations add InitialCreate; # Crear
dotnet ef database update; # Aplicar migración
```

## Swagger (endpoints)

```markdown
https://localhost:7071/swagger/index.html
```
