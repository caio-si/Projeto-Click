# 🖱️ Click Automation - Instruções de Uso

## 📋 Como Compilar e Executar

### Opção 1: Compilação Rápida
```bash
# Compilar e executar diretamente
dotnet run --project ClickAutomation.csproj
```

### Opção 2: Gerar Executável Único
```bash
# Executar o script de build
build.bat
```

### Opção 3: Compilação Manual
```bash
# Compilar
dotnet build ClickAutomation.csproj --configuration Release

# Gerar executável único
dotnet publish ClickAutomation.csproj --configuration Release --runtime win-x64 --self-contained true --single-file --output ./publish
```

## 🎮 Como Usar o Software

### 1. **Configuração Inicial**
- Abra o software
- Use o slider para definir o intervalo entre cliques (1-300 segundos)
- **Recomendado**: 30-60 segundos para Teams

### 2. **Iniciar o Click Automático**
- Clique no botão "▶️ Iniciar"
- O indicador ficará verde e pulsante
- O software começará a clicar automaticamente

### 3. **Monitorar Atividade**
- **Indicador Verde**: Software ativo e funcionando
- **Contador**: Número de cliques realizados
- **Tempo Ativo**: Duração da sessão atual
- **Próximo Click**: Tempo restante para o próximo clique

### 4. **Parar o Software**
- Clique no botão "⏹️ Parar"
- O indicador ficará vermelho
- Todas as operações serão interrompidas

## ⚙️ Funcionalidades

### ✅ **O que o Software Faz**
- Clica com o botão **direito** do mouse
- Clique na **posição atual** do cursor (não move o mouse)
- Intervalos configuráveis de 1 a 300 segundos
- Interface intuitiva com animações
- Estatísticas em tempo real

### ❌ **O que o Software NÃO Faz**
- Não move o cursor
- Não clica com botão esquerdo
- Não interfere com outras aplicações
- Não consome muitos recursos

## 🔧 Configurações Avançadas

### **Intervalos Recomendados**
- **Teams**: 30-60 segundos
- **Discord**: 60-120 segundos  
- **Outros Apps**: 15-30 segundos

### **Dicas de Uso**
1. **Posicione o cursor** em uma área segura antes de iniciar
2. **Use intervalos maiores** para evitar detecção
3. **Monitore o contador** para verificar se está funcionando
4. **Pare o software** quando não precisar mais

## 🚨 Avisos Importantes

### **Uso Responsável**
- Use apenas para fins legítimos
- Respeite as políticas da sua empresa
- Não abuse em ambientes corporativos
- Mantenha o software atualizado

### **Segurança**
- O software não coleta dados pessoais
- Não envia informações para servidores externos
- Funciona completamente offline
- Código fonte disponível para auditoria

## 🐛 Solução de Problemas

### **Software não inicia**
- Verifique se tem .NET 6.0 instalado
- Execute como administrador se necessário
- Verifique se o Windows Defender não está bloqueando

### **Cliques não funcionam**
- Verifique se o cursor está em uma área clicável
- Teste com intervalos maiores
- Reinicie o software

### **Interface não responde**
- Feche e abra o software novamente
- Verifique se não há outros programas interferindo

## 📞 Suporte

Para problemas ou dúvidas:
1. Verifique este arquivo de instruções
2. Consulte o README.md para detalhes técnicos
3. Verifique se está usando a versão mais recente

---

**Desenvolvido para produtividade**

**Desenvolvido por Caio da Silva Figueredo**
