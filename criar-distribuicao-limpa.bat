@echo off
echo ========================================
echo    Criando Distribuição Limpa
echo ========================================
echo.

echo [1/3] Limpando distribuições anteriores...
if exist "ClickAutomation-Distribuicao-Limpa.zip" del "ClickAutomation-Distribuicao-Limpa.zip"
if exist "ClickAutomation-Distribuicao-Limpa" rmdir /s /q "ClickAutomation-Distribuicao-Limpa"

echo.
echo [2/3] Criando pasta de distribuição limpa...
mkdir "ClickAutomation-Distribuicao-Limpa"

echo Copiando apenas o executável principal...
copy "publish\ClickAutomation.exe" "ClickAutomation-Distribuicao-Limpa\"

echo Copiando documentação...
copy "README.md" "ClickAutomation-Distribuicao-Limpa\"
copy "INSTRUCOES.md" "ClickAutomation-Distribuicao-Limpa\"

echo.
echo [3/3] Criando arquivo de instruções...
echo # Click Automation - Instruções de Uso > "ClickAutomation-Distribuicao-Limpa\COMO-USAR.txt"
echo. >> "ClickAutomation-Distribuicao-Limpa\COMO-USAR.txt"
echo 1. Execute o arquivo ClickAutomation.exe >> "ClickAutomation-Distribuicao-Limpa\COMO-USAR.txt"
echo 2. Configure o intervalo desejado (recomendado: 30-60 segundos) >> "ClickAutomation-Distribuicao-Limpa\COMO-USAR.txt"
echo 3. Clique em "Iniciar" para começar o click automático >> "ClickAutomation-Distribuicao-Limpa\COMO-USAR.txt"
echo 4. Clique em "Parar" para interromper >> "ClickAutomation-Distribuicao-Limpa\COMO-USAR.txt"
echo. >> "ClickAutomation-Distribuicao-Limpa\COMO-USAR.txt"
echo Desenvolvido por Caio da Silva Figueredo >> "ClickAutomation-Distribuicao-Limpa\COMO-USAR.txt"

echo.
echo ========================================
echo    DISTRIBUIÇÃO LIMPA CRIADA!
echo ========================================
echo.
echo Pasta: ClickAutomation-Distribuicao-Limpa\
echo.
echo Conteúdo:
echo - ClickAutomation.exe (executável principal)
echo - README.md (documentação técnica)
echo - INSTRUCOES.md (guia detalhado)
echo - COMO-USAR.txt (instruções rápidas)
echo.
echo Tamanho total: ~150 MB
echo.
echo Para distribuir: compacte a pasta em ZIP
echo.
pause




