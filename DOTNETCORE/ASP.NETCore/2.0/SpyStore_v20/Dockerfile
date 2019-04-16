FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 8080
EXPOSE 44300
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "SpyStore_v20.dll"]
