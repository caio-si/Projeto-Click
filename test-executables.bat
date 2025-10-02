@echo off
echo ========================================
echo    Teste de Executáveis - Click Automation
echo ========================================
echo.

echo [1/3] Testando executável publish-simple (requer .NET 6.0)...
echo Executando: .\publish-simple\ClickAutomation.exe
start "" ".\publish-simple\ClickAutomation.exe"
timeout /t 3 /nobreak >nul
echo.

echo [2/3] Testando executável publish-working (self-contained)...
echo Executando: .\publish-working\ClickAutomation.exe
start "" ".\publish-working\ClickAutomation.exe"
timeout /t 3 /nobreak >nul
echo.

echo [3/3] Testando executável publish (single-file)...
echo Executando: .\publish\ClickAutomation.exe
start "" ".\publish\ClickAutomation.exe"
timeout /t 3 /nobreak >nul
echo.

echo ========================================
echo    TESTE CONCLUÍDO
echo ========================================
echo.
echo Verifique se alguma janela do Click Automation abriu.
echo Se nenhuma abriu, pode haver problema de compatibilidade.
echo.
echo Executáveis testados:
echo - publish-simple\ClickAutomation.exe (183 KB - requer .NET 6.0)
echo - publish-working\ClickAutomation.exe (self-contained com DLLs)
echo - publish\ClickAutomation.exe (single-file 153 MB)
echo.
pause




