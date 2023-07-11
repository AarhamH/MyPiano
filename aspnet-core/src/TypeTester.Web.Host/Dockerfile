FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/TypeTester.Web.Host/TypeTester.Web.Host.csproj", "src/TypeTester.Web.Host/"]
COPY ["src/TypeTester.Web.Core/TypeTester.Web.Core.csproj", "src/TypeTester.Web.Core/"]
COPY ["src/TypeTester.Application/TypeTester.Application.csproj", "src/TypeTester.Application/"]
COPY ["src/TypeTester.Core/TypeTester.Core.csproj", "src/TypeTester.Core/"]
COPY ["src/TypeTester.EntityFrameworkCore/TypeTester.EntityFrameworkCore.csproj", "src/TypeTester.EntityFrameworkCore/"]
WORKDIR "/src/src/TypeTester.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/TypeTester.Web.Host", "src/TypeTester.Web.Host"]
COPY ["src/TypeTester.Web.Core", "src/TypeTester.Web.Core"]
COPY ["src/TypeTester.Application", "src/TypeTester.Application"]
COPY ["src/TypeTester.Core", "src/TypeTester.Core"]
COPY ["src/TypeTester.EntityFrameworkCore", "src/TypeTester.EntityFrameworkCore"]
WORKDIR "/src/src/TypeTester.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "TypeTester.Web.Host.dll"]
