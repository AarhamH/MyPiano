FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Install PostgreSQL client
RUN apt-get update && apt-get install -y postgresql-client

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out ./

# Set up environment variables for PostgreSQL connection
ENV POSTGRES_USER postgres
ENV POSTGRES_PASSWORD A_rham123
ENV POSTGRES_HOST localhost
ENV POSTGRES_DB WebAPI
ENV POSTGRES_PORT 5432

# Update the connection string to use PostgreSQL
# Replace the connection string with the appropriate format for your application
ENV CONNECTION_STRING "Host=${POSTGRES_HOST};Port=${POSTGRES_PORT};Database=${POSTGRES_DB};Username=${POSTGRES_USER};Password=${POSTGRES_PASSWORD}"

ENTRYPOINT ["dotnet", "WebAPI.dll"]