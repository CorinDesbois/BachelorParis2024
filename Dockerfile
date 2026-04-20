# Étape 1 : Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copier la solution et les projets
COPY BachelorParis2024.sln ./
COPY BachelorParis2024/*.csproj BachelorParis2024/
COPY BachelorParis2024.Models/*.csproj BachelorParis2024.Models/
COPY BachelorParis2024.Repository/*.csproj BachelorParis2024.Repository/
COPY BachelorParis2024.Mocks/*.csproj BachelorParis2024.Mocks/

# Restaurer les dépendances
RUN dotnet restore

# Copier tout le reste
COPY . .

# Build + publish
RUN dotnet publish BachelorParis2024/BachelorParis2024.csproj -c Release -o /app/out

# Étape 2 : Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "BachelorParis2024.dll"]
