%windir%\microsoft.net\framework\v4.0.30319\msbuild /property:Configuration=Release cccp.sln
@IF %ERRORLEVEL% NEQ 0 PAUSE