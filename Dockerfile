# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/SmartPoultry.Web.Host/SmartPoultry.Web.Host.csproj", "src/SmartPoultry.Web.Host/"]
COPY ["src/SmartPoultry.Web.Core/SmartPoultry.Web.Core.csproj", "src/SmartPoultry.Web.Core/"]
COPY ["src/SmartPoultry.Application/SmartPoultry.Application.csproj", "src/SmartPoultry.Application/"]
COPY ["src/SmartPoultry.Core/SmartPoultry.Core.csproj", "src/SmartPoultry.Core/"]
COPY ["src/SmartPoultry.EntityFrameworkCore/SmartPoultry.EntityFrameworkCore.csproj", "src/SmartPoultry.EntityFrameworkCore/"]
WORKDIR "/src/src/SmartPoultry.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/SmartPoultry.Web.Host", "src/SmartPoultry.Web.Host"]
COPY ["src/SmartPoultry.Web.Core", "src/SmartPoultry.Web.Core"]
COPY ["src/SmartPoultry.Application", "src/SmartPoultry.Application"]
COPY ["src/SmartPoultry.Core", "src/SmartPoultry.Core"]
COPY ["src/SmartPoultry.EntityFrameworkCore", "src/SmartPoultry.EntityFrameworkCore"]
WORKDIR "/src/src/SmartPoultry.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "SmartPoultry.Web.Host.dll"]

