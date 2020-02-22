#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SpyStore.Hol.Service/SpyStore.Hol.Service.csproj", "SpyStore.Hol.Service/"]
COPY ["SpyStore.Hol.Service/SpyStore.Hol.Service.xml", "app/"]
COPY ["SpyStore.Hol.Models/SpyStore.Hol.Models.csproj", "SpyStore.Hol.Models/"]
COPY ["SpyStore.Hol.Dal/SpyStore.Hol.Dal.csproj", "SpyStore.Hol.Dal/"]
RUN dotnet restore "SpyStore.Hol.Service/SpyStore.Hol.Service.csproj"
COPY . .
WORKDIR "/src/SpyStore.Hol.Service"
RUN dotnet build "SpyStore.Hol.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpyStore.Hol.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpyStore.Hol.Service.dll"]