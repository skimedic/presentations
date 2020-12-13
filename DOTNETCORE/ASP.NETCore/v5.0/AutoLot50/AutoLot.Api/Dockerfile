#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["AutoLot.Api/AutoLot.Api.csproj", "AutoLot.Api/"]
COPY ["AutoLot.Api/AutoLot.Api.xml", "app/"]
COPY ["AutoLot.Models/AutoLot.Models.csproj", "AutoLot.Models/"]
COPY ["AutoLot.Services/AutoLot.Services.csproj", "AutoLot.Services/"]
COPY ["AutoLot.Dal/AutoLot.Dal.csproj", "AutoLot.Dal/"]
RUN dotnet restore "AutoLot.Api/AutoLot.Api.csproj"
COPY . .
WORKDIR "/src/AutoLot.Api"
RUN dotnet build "AutoLot.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutoLot.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoLot.Api.dll"]