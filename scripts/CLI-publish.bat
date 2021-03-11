@echo off
rem ReviewFileToJsonCLIを自己完結型でwin-x86とlinux-x64向けに発行し、GitHubのReleaseにアップロードするためにzip圧縮するバッチファイル
dotnet publish ..\src\ReviewFileToJsonCLI\ReviewFileToJsonCLI.csproj -o ..\src\ReviewFileToJsonCLI\bin\Release\linux-x64-publish -c Release --self-contained=true -r linux-x64 -p:PublishSingleFile=true -p:PublishTrimmed=true
powershell Compress-Archive -Path ..\src\ReviewFileToJsonCLI\bin\Release\linux-x64-publish -DestinationPath ..\src\ReviewFileToJsonCLI\bin\Release\linux-x64-publish.zip -Force
dotnet publish ..\src\ReviewFileToJsonCLI\ReviewFileToJsonCLI.csproj -o ..\src\ReviewFileToJsonCLI\bin\Release\win-x86-publish -c Release --self-contained true -r win-x86 -p:PublishSingleFile=true -p:PublishTrimmed=true
powershell Compress-Archive -Path ..\src\ReviewFileToJsonCLI\bin\Release\win-x86-publish -DestinationPath ..\src\ReviewFileToJsonCLI\bin\Release\win-x86-publish.zip -Force
@echo --- Finished ---
pause > nul