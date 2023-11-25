# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0.100-1-alpine3.18 AS workspace
WORKDIR /work

FROM workspace AS builder
WORKDIR /build
COPY ./WebAppBlueprintCS.sln .
COPY ./src/WebApplication ./src/WebApplication
RUN dotnet restore ./src/WebApplication/Presentation/Presentation.csproj
RUN dotnet publish ./src/WebApplication/Presentation/Presentation.csproj -c Release -o out --no-restore

WORKDIR /work
###########DEBUGGER###########
COPY ./JetBrains.Rider.RemoteDebuggerUploads.linux-x64.2023.2.zip /work/
RUN mkdir -p /work/RiderRemoteDebugger/2023.2.2 && unzip -o /work/JetBrains.Rider.RemoteDebuggerUploads.linux-x64.2023.2.zip -d /work/RiderRemoteDebugger/2023.2.2/
COPY ./jetbrains_debugger_agent_20230319.24.0 /work/jetbrains_debugger_agent
#############################

FROM mcr.microsoft.com/dotnet/aspnet:8.0.0-alpine3.18 AS runtime
RUN ln -sf /usr/share/zoneinfo/posix/Japan /etc/localtime
RUN apk add bash
WORKDIR /app
COPY --from=builder /build/out .
COPY ./src/WebApplication/entrypoint.sh /usr/local/bin/

###########DEBUGGER###########
COPY --from=builder /work/jetbrains_debugger_agent /usr/local/bin/
RUN chmod +x /usr/local/bin/jetbrains_debugger_agent
COPY --from=builder /work/RiderRemoteDebugger/2023.2.2/ /usr/local/bin/RiderRemoteDebugger/2023.2.2/
##############################

COPY --from=pyroscope/pyroscope-dotnet:0.8.8-musl /Pyroscope.Profiler.Native.so ./Pyroscope.Profiler.Native.so
COPY --from=pyroscope/pyroscope-dotnet:0.8.8-musl /Pyroscope.Linux.ApiWrapper.x64.so ./Pyroscope.Linux.ApiWrapper.x64.so

EXPOSE 5022
ENTRYPOINT [ "entrypoint.sh" ]