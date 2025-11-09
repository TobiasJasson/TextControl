# Imagen base de runtime .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Imagen para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el archivo del proyecto y restaurar dependencias
COPY ["API.Server/API.Server.csproj", "API.Server/"]
RUN dotnet restore "API.Server/API.Server.csproj"

# Copiar todo el código y compilar
COPY . .
WORKDIR "/src/API.Server"
RUN dotnet publish "API.Server.csproj" -c Release -o /app/publish

# Imagen final
FROM base AS final
WORKDIR /app

# Copiamos el publishado
COPY --from=build /app/publish .

# Copiamos la carpeta init con el script SQL (si la agregás)
COPY ["API.Server/init/", "./init/"]

ENTRYPOINT ["dotnet", "API.Server.dll"]