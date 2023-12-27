#!/usr/bin/env bash
/usr/local/bin/jetbrains_debugger_agent -port 5033 -login debuguser -password debuguser &

dotnet /app/ManagementConsole.Presentation.dll
