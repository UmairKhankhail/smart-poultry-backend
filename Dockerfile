# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

# Copy solution and project files
COPY SmartPoultry.sln ./
COPY src/SmartPoultry.Web.Host/SmartPoultry.Web.Host.csproj ./src/SmartPoultry.Web.Host/
COPY src/SmartPoultry.Web.Core/SmartPoultry.Web.Core.csproj ./src/SmartPoultry.Web.Core/

# Restore dependencies
RUN dotnet restore SmartPoultry.sln

# Copy the rest of the code
COPY . .

# Build and publish the app
WORKDIR /app/src/SmartPoultry.Web.Host
RUN dotnet publish -c Release -o /out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app
COPY --from=build /out .

ENTRYPOINT ["dotnet", "SmartPoultry.Web.Host.dll"]
