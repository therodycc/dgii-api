## 🚀 Tecnologías

- **.NET 8** - Framework principal
- **C# 12** - Lenguaje de programación
- **Entity Framework Core 8** - ORM para base de datos
- **SQL Server** - Base de datos
- **AutoMapper** - Mapeo de objetos
- **Swagger/OpenAPI** - Documentación de endpoints
- **xUnit & Moq** - Tests unitarios

## 📋 Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (opcional para SQL Server)
- SQL Server (local o en contenedor)
- Git

## 🔧 Configuración del entorno

### 1. Clonar el repositorio

```bash
git clone https://github.com/therodycc/dgii-api.git
cd dgii-api
```

### 2. SQL Server con Docker (macOS/Linux/Windows)

```bash
docker run -e 'ACCEPT_EULA=Y' \
           -e 'SA_PASSWORD=MiC0ntr@s3ñ@' \
           -p 1433:1433 \
           --name sqlserver \
           -v ~/docker/sqlserver:/var/opt/mssql \
           -d mcr.microsoft.com/mssql/server:2022-latest

# Verificar que el contenedor está corriendo
docker ps

# Conectarse al contenedor (opcional)
docker exec -it sqlserver /bin/bash
```

`***You can use a database administrator tool like dbeaver***`

![Dbeaver](https://repository-images.githubusercontent.com/44662669/f3f5c080-808b-11ea-9713-2bea65875d95)

### 3. Secrets

```bash
# Inicializar secrets
dotnet user-secrets init

# Configurar connection string
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Data Source=localhost,1433;Initial Catalog=dgii_db;User ID=SA;Password=MiC0ntr@s3ñ@;TrustServerCertificate=True;"
```

### 4. Restaurar paquetes NuGet

```bash
dotnet restore
```

# 📦 Instalación y ejecución

```bash
dotnet ef database update;
dotnet run seeddata;
dotnet watch;
```

## Swagger (endpoints)

```markdown
https://localhost:7071/swagger/index.html
```

### 🗄️ Migraciones de Base de Datos
```bash
# Crear una nueva migración
dotnet ef migrations add NombreMigracion

# Aplicar migraciones a la base de datos
dotnet ef database update

# Eliminar la última migración (no aplicada)
dotnet ef migrations remove

# Revertir la base de datos a una migración específica
dotnet ef database update NombreMigracionAnterior

# Generar script SQL
dotnet ef migrations script -o script.sql

# Ver migraciones aplicadas
dotnet ef migrations list
```
