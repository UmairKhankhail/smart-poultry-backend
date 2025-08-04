# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:2.2 AS build

WORKDIR /app

# Copy solution and all projects
COPY SmartPoultry.sln ./
COPY src/ ./src/

# Restore dependencies
WORKDIR /app/src/SmartPoultry.Web.Host
RUN dotnet restore

# Publish app
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:2.2

WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SmartPoultry.Web.Host.dll"]
