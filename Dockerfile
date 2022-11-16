# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0.100-alpine3.14 AS workspace
WORKDIR /work

FROM workspace AS builder
WORKDIR /build
COPY ./DotnetMetricTest.sln .
COPY ./src/WebApplication ./src/WebApplication

RUN dotnet restore ./src/WebApplication/Presentation/Presentation.csproj
RUN dotnet publish ./src/WebApplication/Presentation/Presentation.csproj -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
RUN ln -sf /usr/share/zoneinfo/posix/Japan /etc/localtime
WORKDIR /app
COPY --from=builder /build/out .
ENTRYPOINT [ "dotnet", "DotnetMetricTestApp.dll"]