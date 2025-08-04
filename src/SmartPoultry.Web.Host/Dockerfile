# Use SDK image to build the app
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /src

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY src ./src

WORKDIR /src/SmartPoultry.Web.Host
RUN dotnet restore

# Build the app
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SmartPoultry.Web.Host.dll"]
