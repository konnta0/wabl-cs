# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:7.0.305-alpine3.18 AS workspace
WORKDIR /work

FROM workspace AS builder
WORKDIR /build
COPY ./WebAppBlueprintCS.sln .
COPY ./src/WebApplication ./src/WebApplication

RUN dotnet restore ./src/WebApplication/Presentation/Presentation.csproj
RUN dotnet publish ./src/WebApplication/Presentation/Presentation.csproj -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
RUN ln -sf /usr/share/zoneinfo/posix/Japan /etc/localtime
WORKDIR /app
COPY --from=builder /build/out .
COPY ./entrypoint.sh /usr/local/bin/
RUN apt-get update && apt-get install -y curl
RUN \
    curl -L "https://download.jetbrains.com/rider/ssh-remote-debugging/linux-x64/jetbrains_debugger_agent_20230319.24.0" \
    -o /usr/local/bin/debugger && \
    chmod +x /usr/local/bin/debugger
EXPOSE 7777
ENTRYPOINT [ "entrypoint.sh" ]