#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API-Inscription.csproj", "API-Inscription/"]
WORKDIR "/src/API-Inscription/"
COPY . .
RUN dotnet restore "API-Inscription.csproj"

USER root
RUN dotnet build "API-Inscription.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API-Inscription.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API-Inscription.dll"]