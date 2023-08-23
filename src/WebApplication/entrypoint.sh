#!/usr/bin/env bash
/usr/local/bin/jetbrains_debugger_agent -port 5022 -login debuguser -password debuguser &

dotnet /app/WebAppBlueprintCS.dll
