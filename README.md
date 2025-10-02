# Click Automation - Anti Inatividade

Um software desenvolvido em C# WPF para realizar cliques automáticos do mouse, ideal para manter status ativo em aplicações como Microsoft Teams.

## 🚀 Funcionalidades

- **Click Automático**: Clique direito do mouse em intervalos configuráveis
- **Interface Intuitiva**: Design moderno e fácil de usar
- **Configuração Flexível**: Intervalos de 1 a 300 segundos
- **Animações Visuais**: Indicadores visuais de atividade
- **Estatísticas**: Contador de cliques e tempo ativo
- **Executável Único**: Sem dependências externas

## 🎯 Características Técnicas

- **Framework**: .NET 6.0 WPF
- **Plataforma**: Windows 10/11
- **Arquitetura**: MVVM com Services
- **APIs**: Windows User32.dll para simulação de mouse
- **Threading**: Background tasks para operações não-bloqueantes

## 📦 Estrutura do Projeto

```
ClickAutomation/
├── Services/
│   ├── ClickService.cs          # Serviço principal de click
│   ├── AnimationHelper.cs       # Gerenciador de animações
│   └── ConfigurationService.cs  # Persistência de configurações
├── MainWindow.xaml              # Interface principal
├── MainWindow.xaml.cs           # Lógica da interface
├── App.xaml                     # Configuração da aplicação
└── ClickAutomation.csproj       # Arquivo do projeto
```

## 🛠️ Como Compilar

### Pré-requisitos
- .NET 9.0 SDK ou superior
- Visual Studio 2022 ou VS Code
- Windows 10/11

### Compilação
```bash
# Restaurar dependências
dotnet restore

# Compilar o projeto
dotnet build --configuration Release

# Publicar executável único
dotnet publish --configuration Release --runtime win-x64 --self-contained true --single-file
```

## 📦 Versões de Distribuição

O projeto oferece três versões diferentes para distribuição, cada uma com suas características específicas:

### **1. Publish-Simple (186 KB)**
```bash
dotnet publish --configuration Release --runtime win-x64 --self-contained false --output ./publish-simple
```

**Características:**
- ✅ **Tamanho mínimo** (186 KB)
- ✅ **Compilação rápida**
- ❌ **Requer .NET 9.0** instalado no computador de destino
- ❌ **Múltiplos arquivos** (executável + DLLs do .NET)

**Ideal para:** Desenvolvimento e testes locais

### **2. Publish-Working (120 MB)**
```bash
dotnet publish --configuration Release --runtime win-x64 --self-contained true --output ./publish-working
```

**Características:**
- ✅ **Self-contained** (não precisa do .NET instalado)
- ✅ **Múltiplos arquivos** (mais estável)
- ✅ **Compatibilidade máxima**
- ❌ **Tamanho maior** (120 MB)
- ❌ **Muitos arquivos** para distribuir

**Ideal para:** Distribuição quando você pode enviar uma pasta completa

### **3. Publish Single-File (120 MB)**
```bash
dotnet publish --configuration Release --runtime win-x64 --self-contained true --output ./publish --property:PublishSingleFile=true
```

**Características:**
- ✅ **Arquivo único** (apenas 1 arquivo)
- ✅ **Self-contained** (não precisa do .NET instalado)
- ✅ **Fácil distribuição** (só enviar 1 arquivo)
- ❌ **Tamanho grande** (120 MB)
- ❌ **Pode ter problemas** de compatibilidade em alguns sistemas

**Ideal para:** Distribuição quando você quer enviar apenas 1 arquivo

### **📊 Comparação das Versões**

| Versão | Tamanho | Arquivos | .NET Necessário | Estabilidade | Facilidade |
|--------|---------|----------|-----------------|--------------|------------|
| Simple | 186 KB | Múltiplos | ✅ Sim | ⭐⭐⭐ | ⭐⭐ |
| Working | 120 MB | Múltiplos | ❌ Não | ⭐⭐⭐⭐⭐ | ⭐⭐⭐ |
| Single-File | 120 MB | 1 arquivo | ❌ Não | ⭐⭐⭐ | ⭐⭐⭐⭐⭐ |

### **🎯 Recomendação de Uso**

- **Desenvolvimento:** Use `publish-simple`
- **Distribuição geral:** Use `publish-working`
- **Distribuição simples:** Use `publish` (single-file)

## 🎮 Como Usar

1. **Configurar Intervalo**: Use o slider para definir o tempo entre cliques (1-300 segundos)
2. **Iniciar**: Clique no botão "▶️ Iniciar" para começar o click automático
3. **Monitorar**: Acompanhe as estatísticas e indicadores visuais
4. **Parar**: Clique em "⏹️ Parar" para interromper a operação

## ⚙️ Configurações

- **Intervalo Recomendado**: 30-60 segundos para Teams
- **Posição do Mouse**: Clique na posição atual (não move o cursor)
- **Tipo de Click**: Botão direito do mouse
- **Persistência**: Configurações salvas automaticamente

## 🔒 Segurança

- **Não Move o Cursor**: Apenas clica na posição atual
- **Detecção de Janelas**: Evita cliques em aplicações sensíveis
- **Baixo Consumo**: Otimizado para uso contínuo
- **Logs de Atividade**: Rastreamento de operações

## 📊 Recursos da Interface

- **Indicador de Status**: Círculo colorido com animação de pulso
- **Controles Intuitivos**: Botões Start/Stop com feedback visual
- **Estatísticas em Tempo Real**: Cliques realizados, tempo ativo, próximo click
- **Design Responsivo**: Adapta-se a diferentes tamanhos de tela
- **Animações Suaves**: Feedback visual para todas as ações

## 🚨 Avisos Importantes

- Use com responsabilidade e moderação
- Não abuse em ambientes corporativos
- Respeite as políticas de uso dos aplicativos
- Mantenha o software atualizado

## 📝 Licença

Este projeto é desenvolvido para fins educacionais e de produtividade pessoal.

## 🔧 Desenvolvimento

### Tecnologias Utilizadas
- **C# 10** - Linguagem principal
- **WPF** - Interface de usuário
- **Windows API** - Simulação de mouse
- **System.Threading** - Operações assíncronas
- **JSON** - Persistência de configurações

### Melhorias Futuras
- [ ] Hotkeys globais
- [ ] Minimizar para system tray
- [ ] Múltiplos perfis de configuração
- [ ] Logs detalhados
- [ ] Modo "inteligente" (detecta atividade real)

---

**Desenvolvido com ❤️ para produtividade**

**Desenvolvido por Caio da Silva Figueredo**
