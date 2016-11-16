FROM microsoft/dotnet:1.0.1-core
ARG who="Pim"
CMD "dotnet HelloThere.dll Pim"
ARG source=.
WORKDIR /app
COPY $source .
