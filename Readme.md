#  JOGO DA FORCA

![]()

## Introdução

Um jogo da forca com tema de frutas que permite ao jogador dar 5 chutes para tentar adivinhar a palavra secreta.

## Funções

**- Palavra secreta:** Seleciona uma palavra secreta de maneira aleatória a partir de uma lista de palavras não revelada ao usúario e torna essa palavra o objetivo do jogo,bem como a revela para o usúario no final dele. 

**- Tratamento de exeções:** faz o tratamento para não poder passar um valor nulo ao chutar uma letra.

**- Tentativas:** O usúario tem 5 chutes de letra para tentar adivinhar a palavra,caso ele seja excedido o jogo acaba e a palavra é revelada e é dada ao jogador a opção de tentar novamente com uma nova palavra secreta.

**- Desenho da forca:** uma forca é mostrada durante o jogo,a medida que o jogador erra a forca vai sendo preenchida por um "corpo".

## Como ultilizar

1. Extraia o arquivo JogoDaForca.ConsoleApp do repositório com .zip;

2. Restaure as dependecias do projeto com o ```comando```:
```
dotnet restore
```
3. Agora va até o diretório raiz e execute no terminal com o ```comando```:
```
dotnet run --project JogoDaForca.ConsoleApp
```

## Requisitos

.NET SDK (versão 10)