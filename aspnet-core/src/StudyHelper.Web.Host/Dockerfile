FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/StudyHelper.Web.Host/StudyHelper.Web.Host.csproj", "src/StudyHelper.Web.Host/"]
COPY ["src/StudyHelper.Web.Core/StudyHelper.Web.Core.csproj", "src/StudyHelper.Web.Core/"]
COPY ["src/StudyHelper.Application/StudyHelper.Application.csproj", "src/StudyHelper.Application/"]
COPY ["src/StudyHelper.Core/StudyHelper.Core.csproj", "src/StudyHelper.Core/"]
COPY ["src/StudyHelper.EntityFrameworkCore/StudyHelper.EntityFrameworkCore.csproj", "src/StudyHelper.EntityFrameworkCore/"]
WORKDIR "/src/src/StudyHelper.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/StudyHelper.Web.Host", "src/StudyHelper.Web.Host"]
COPY ["src/StudyHelper.Web.Core", "src/StudyHelper.Web.Core"]
COPY ["src/StudyHelper.Application", "src/StudyHelper.Application"]
COPY ["src/StudyHelper.Core", "src/StudyHelper.Core"]
COPY ["src/StudyHelper.EntityFrameworkCore", "src/StudyHelper.EntityFrameworkCore"]
WORKDIR "/src/src/StudyHelper.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "StudyHelper.Web.Host.dll"]
