FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SpyStore.Hol.Service/SpyStore.Hol.Service.csproj", "SpyStore.Hol.Service/"]
COPY ["SpyStore.Hol.Models/SpyStore.Hol.Models.csproj", "SpyStore.Hol.Models/"]
COPY ["SpyStore.Hol.Dal/SpyStore.Hol.Dal.csproj", "SpyStore.Hol.Dal/"]
RUN dotnet restore "SpyStore.Hol.Service/SpyStore.Hol.Service.csproj"
COPY . .
WORKDIR "/src/SpyStore.Hol.Service"
RUN dotnet build "SpyStore.Hol.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SpyStore.Hol.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SpyStore.Hol.Service.dll"]