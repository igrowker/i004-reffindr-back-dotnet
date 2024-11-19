# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Reffindr.Api/Reffindr.Api.csproj", "Reffindr.Api/"]
COPY ["Reffindr.Application/Reffindr.Application.csproj", "Reffindr.Application/"]
COPY ["Reffindr.Infrastructure/Reffindr.Infrastructure.csproj", "Reffindr.Infrastructure/"]
COPY ["Reffindr.Domain/Reffindr.Domain.csproj", "Reffindr.Domain/"]
COPY ["Reffindr.Shared/Reffindr.Shared.csproj", "Reffindr.Shared/"]
RUN dotnet restore "./Reffindr.Api/Reffindr.Api.csproj"
COPY . .
WORKDIR "/src/Reffindr.Api"
RUN dotnet build "./Reffindr.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Reffindr.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reffindr.Api.dll"]