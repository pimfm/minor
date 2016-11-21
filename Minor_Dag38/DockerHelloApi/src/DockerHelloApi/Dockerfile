FROM microsoft/dotnet:1.0.1-core
EXPOSE 80
COPY ./bin/Debug/netcoreapp1.0/publish .
ENTRYPOINT ["dotnet", "DockerHelloApi.dll"]