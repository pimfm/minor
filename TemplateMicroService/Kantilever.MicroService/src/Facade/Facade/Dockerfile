FROM microsoft/dotnet:1.0.1-core
ENTRYPOINT ["dotnet", "Kantilever.MicroService.Facade.dll"]
ARG source=./bin/Debug/netcoreapp1.0/publish
WORKDIR /app
COPY $source .
