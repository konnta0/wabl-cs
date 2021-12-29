# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0.100-alpine3.14 AS workspace

FROM workspace AS builder
WORKDIR /build
COPY ./DotnetMetricTest.sln .
COPY ./src ./src
RUN dotnet restore
RUN dotnet publish -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=builder /build/out .
ENTRYPOINT [ "dotnet", "DotnetMetricTestApp.dll"]