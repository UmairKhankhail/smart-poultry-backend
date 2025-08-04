# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

# Copy solution file
COPY SmartPoultry.sln ./

# Copy all project files (as referenced in the .sln)
COPY src/SmartPoultry.Web.Host/SmartPoultry.Web.Host.csproj ./src/SmartPoultry.Web.Host/
COPY src/SmartPoultry.Web.Core/SmartPoultry.Web.Core.csproj ./src/SmartPoultry.Web.Core/
COPY src/SmartPoultry.Core/SmartPoultry.Core.csproj ./src/SmartPoultry.Core/
COPY src/SmartPoultry.Application/SmartPoultry.Application.csproj ./src/SmartPoultry.Application/
COPY src/SmartPoultry.Migrator/SmartPoultry.Migrator.csproj ./src/SmartPoultry.Migrator/
COPY src/SmartPoultry.EntityFrameworkCore/SmartPoultry.EntityFrameworkCore.csproj ./src/SmartPoultry.EntityFrameworkCore/

# Restore dependencies
RUN dotnet restore SmartPoultry.sln

# Copy entire source
COPY . .

# Build and publish app
WORKDIR /app/src/SmartPoultry.Web.Host
RUN dotnet publish -c Release -o /out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app
COPY --from=build /out .

ENTRYPOINT ["dotnet", "SmartPoultry.Web.Host.dll"]
