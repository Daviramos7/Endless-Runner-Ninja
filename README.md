# Endless Runner Ninja

Este é um jogo digital 2D do subgênero *Endless Runner* desenvolvido na **Unity 6 (6000.3.10f1)** utilizando o **Universal Render Pipeline (URP)**. O projeto foi projetado com foco em alta performance (utilizando a API gráfica Vulkan/DirectX), modularidade de código e geração procedural de obstáculos, servindo como Produto Mínimo Viável (MVP) para avaliação de Game Engine.

## 🛠️ Tecnologias e Arquitetura

- **Engine:** Unity 6 LTS
- **Pipeline Gráfico:** Universal Render Pipeline (URP) com Renderer 2D dedicado.
- **Linguagem:** C# (.NET Core)
- **Física:** Rigidbody 2D e Sistema de Colisões Baseado em Triggers (`OnTriggerEnter2D`).
- **Target Platform:** Windows Standalone (X86_64)

## 🗂️ Estrutura de Scripts (Arquitetura do Código)

O core do projeto foi dividido em microsserviços e componentes especializados para garantir o princípio de responsabilidade única:

1. **`PlayerJump.cs`**: Gerencia a física do salto do Samurai, detecção de solo através de *Raycasting* e controle de forças verticais.
2. **`PlayerAtaque.cs`**: Controla o sistema de inventário de projéteis (Shurikens), spawn do prefab do projétil e gerenciamento de recarga.
3. **`PlayerColisao.cs`**: O hub central de triggers. Identifica interações com inimigos (morte), coleta de moedas (pontuação) e coleta de itens (munição). Controla o estado de *Game Over* via manipulação do `Time.timeScale`.
4. **`ShurikenScript.cs`**: Controla o vetor de translação horizontal da Shuriken lançada, velocidade e auto-destruição para otimização de memória.
5. **`GeradorMestre.cs`**: Algoritmo procedural responsável pelo spawn aleatório de pacotes de obstáculos (`Padrao_Moeda_E_Caixa`) em intervalos de tempo dinâmicos.
6. **`Obstaculo.cs`**: Define o comportamento de deslocamento contínuo dos objetos em direção à esquerda da tela, simulando o movimento infinito.
7. **`ParallaxControl.cs`**: Gerencia múltiplas camadas de background (`Layers_0000_9` a `Layer_0011_0`), movendo-as em velocidades proporcionais distintas para criar a ilusão de profundidade profunda em 2D.
8. **`GerenciadorPlacar.cs`**: Responsável pelo cálculo de pontuação em tempo real, persistência do recorde local (*High Score*) e comunicação com a UI.
9. **`MenuGerenciador.cs`**: Manipula o ciclo de vida do jogo na cena de entrada, carregando contextos assincronamente e gerenciando a saída da aplicação.

## 🚀 Funcionalidades Principais

- **Game Loop Completo**: Ciclo fechado de transição de estados (Menu Inicial -> Gameplay -> Game Over com congelamento de engine -> Reinicialização instantânea).
- **Animações Otimizadas**: Spritesheets processados a 30 quadros por segundo para o ciclo de corrida (*Run*) e estados dinâmicos para moedas e projéteis.
- **Física Precisa**: Alinhamento de colisores complexos em nível de pixel (*Pixel-Perfect Collider Alignment*) para evitar colisões fantasmas em alta velocidade.

## ⚙️ Instalação e Execução

1. Certifique-se de extrair o arquivo `.zip` completo do build.
2. Certifique-se de que a pasta de dados do executável (`EndlessRunnerNinja_Data`) está no mesmo diretório que o arquivo principal.
3. Execute o arquivo `EndlessRunnerNinja.exe`.
