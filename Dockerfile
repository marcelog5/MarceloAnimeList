#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MarceloAnimeList.API/MarceloAnimeList.API.csproj", "MarceloAnimeList.API/"]
COPY ["MarceloAnimeList.Service/MarceloAnimeList.Service.csproj", "MarceloAnimeList.Service/"]
COPY ["MarceloAnimeList.Infra/MarceloAnimeList.Infra.csproj", "MarceloAnimeList.Infra/"]
COPY ["MarceloAnimeList.Domain/MarceloAnimeList.Domain.csproj", "MarceloAnimeList.Domain/"]
COPY ["Commom/Commom.csproj", "Commom/"]
RUN dotnet restore "MarceloAnimeList.API/MarceloAnimeList.API.csproj"
COPY . .
WORKDIR "/src/MarceloAnimeList.API"
RUN dotnet build "MarceloAnimeList.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarceloAnimeList.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarceloAnimeList.API.dll"]