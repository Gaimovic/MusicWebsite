FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["MusicShop/MusicShop.csproj", "MusicShop/"]
COPY ["MusicShop.Domain/MusicShop.Domain.csproj", "MusicShop.Domain/"]
COPY ["MusicShop.Features/MusicShop.Features.csproj", "MusicShop.Features/"]
COPY ["MusicShop.Infrastructure/MusicShop.Infrastructure.csproj", "MusicShop.Infrastructure/"]
RUN dotnet restore "MusicShop/MusicShop.csproj"
COPY . .
WORKDIR "/src/MusicShop"
RUN dotnet build "MusicShop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicShop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicShop.dll"]