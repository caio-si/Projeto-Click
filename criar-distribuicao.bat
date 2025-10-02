@echo off
echo ========================================
echo    Criando Pacote de Distribuição
echo ========================================
echo.

echo [1/3] Limpando distribuições anteriores...
if exist "ClickAutomation-Distribuicao.zip" del "ClickAutomation-Distribuicao.zip"
if exist "ClickAutomation-Distribuicao" rmdir /s /q "ClickAutomation-Distribuicao"

echo.
echo [2/3] Criando pasta de distribuição...
mkdir "ClickAutomation-Distribuicao"
xcopy "publish-working\*" "ClickAutomation-Distribuicao\" /E /I /Y

echo.
echo [3/3] Adicionando arquivos de documentação...
copy "README.md" "ClickAutomation-Distribuicao\"
copy "INSTRUCOES.md" "ClickAutomation-Distribuicao\"

echo.
echo ========================================
echo    DISTRIBUIÇÃO CRIADA COM SUCESSO!
echo ========================================
echo.
echo Pasta criada: ClickAutomation-Distribuicao\
echo.
echo Para distribuir:
echo 1. Compacte a pasta ClickAutomation-Distribuicao em ZIP
echo 2. Envie o ZIP para a pessoa
echo 3. A pessoa deve extrair e executar ClickAutomation.exe
echo.
echo Tamanho aproximado: 150-200 MB
echo.
pause




