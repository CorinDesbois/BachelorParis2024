# Étape 1 : Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copier le fichier csproj
COPY source/repos/BachelorParis2024/BachelorParis2024/BachelorParis2024.csproj ./BachelorParis2024/

# Restaurer les dépendances
RUN dotnet restore ./BachelorParis2024/BachelorParis2024.csproj

# Copier tout le code
COPY source/repos/BachelorParis2024/BachelorParis2024/ ./BachelorParis2024/

# Compiler et publier
RUN dotnet publish ./BachelorParis2024/BachelorParis2024.csproj -c Release -o /app/publish

# Étape 2 : Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

# Render fournit le port via la variable d'environnement PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

ENTRYPOINT ["dotnet", "BachelorParis2024.dll"]
