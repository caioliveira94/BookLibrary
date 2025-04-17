#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BookLibrary.API/BookLibrary.API.csproj", "BookLibrary.API/"]
COPY ["BookLibrary.Core/BookLibrary.Core.csproj", "BookLibrary.Core/"]
COPY ["BookLibrary.Data/BookLibrary.Data.csproj", "BookLibrary.Data/"]
RUN dotnet restore "./BookLibrary.API/./BookLibrary.API.csproj"
COPY . .
WORKDIR "/src/BookLibrary.API"
RUN dotnet build "./BookLibrary.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookLibrary.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookLibrary.API.dll"]