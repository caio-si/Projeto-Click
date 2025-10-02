@echo off
echo ========================================
echo    Click Automation - Build Script
echo ========================================
echo.

echo [1/3] Limpando builds anteriores...
dotnet clean ClickAutomation.csproj
if %ERRORLEVEL% neq 0 (
    echo ERRO: Falha ao limpar projeto
    pause
    exit /b 1
)

echo.
echo [2/3] Compilando projeto...
dotnet build ClickAutomation.csproj --configuration Release
if %ERRORLEVEL% neq 0 (
    echo ERRO: Falha na compilação
    pause
    exit /b 1
)

echo.
echo [3/3] Gerando executável único...
dotnet publish ClickAutomation.csproj --configuration Release --runtime win-x64 --self-contained true --output ./publish --property:PublishSingleFile=true --property:IncludeNativeLibrariesForSelfExtract=true
if %ERRORLEVEL% neq 0 (
    echo ERRO: Falha na publicação
    pause
    exit /b 1
)

echo.
echo ========================================
echo    BUILD CONCLUÍDO COM SUCESSO!
echo ========================================
echo.
echo Executável gerado em: ./publish/ClickAutomation.exe
echo Tamanho aproximado: ~15-20 MB
echo.
echo Pressione qualquer tecla para abrir a pasta...
pause >nul
explorer ./publish
