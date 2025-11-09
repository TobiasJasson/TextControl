# Etapa 1: construir frontend (Vite)
FROM node:18 AS vite-build
WORKDIR /app
COPY api.client/package*.json ./
RUN npm install
COPY api.client/ .
RUN npm run build

# Etapa 2: construir backend .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["API/API.Server/API.Server.csproj", "API/API.Server/"]
RUN dotnet restore "API/API.Server/API.Server.csproj"
COPY . .
WORKDIR "/src/API/API.Server"
RUN dotnet publish "API.Server.csproj" -c Release -o /app/publish

# Etapa 3: Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
# Copiar el build de Vite (dist) al wwwroot de la API
COPY --from=vite-build /app/dist ./wwwroot
EXPOSE 8080
ENTRYPOINT ["dotnet", "API.Server.dll"]
