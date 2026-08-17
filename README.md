# KBank.Console
```text
KBank Finances

Aqui você gerencia suas despesas, simples e rápido.

📌 Sobre o projeto

Um sistema para você gerenciar suas financias com controle de dados em historico.
Ele foi feito para o uso diario, ao em vez de tratar com planilhas gigantes, voce tem um simples sistema que gerencia tudo para você.
A proposta do projeto é melhorar a dinâmica de organização financeira.
É um projeto de console para estudos e praticas conforme a conclusão do meu curso de C#

🎯 Objetivos

Pratica de linguagem
Alinhar conceitos não dominantes
Controlar minhas financias, de uma forma mais pessoal e ligada a mim
Concretizar aprendizado visto no curso

🛠️ Tecnologias utilizadas

C#
Bibliotecas .NET
Visual Studio 2022
Git/GitHub

🏗️ Estrutura do projeto

```text
KBank/
├── Models/
│   ├── Banco.cs
│   ├── ContaBancaria.cs
│   └── Transacoes.cs
├── Utils/
│   └── Menu.cs
├── Enums/
│   └── EnumTransacoes.cs
├── Exceptions/
│   ├── ContaExistenteException.cs
│   ├── ContaInexistenteException.cs
│   └── ValorNuloException.cs
└── Program.cs

🧠 Conceitos aplicados

Programação Orientada a Objetos, 
Composição, 
Tratamento de exceções, 
LINQ, 
Persistência de dados, 
Biblioteca .IO

💾 Persistência de dados

Os dados sao armazenados na memoria RAM por meio de uma list<> e salvos no disco em arquivos .txt
Eles são salvos por meios de metodos de busca
São carregados por meio de um metodo de hidratação de dados

📚 O que aprendi com este projeto

Aprendi melhor como funciona persistência de dados, e a diferença da espaço em memoria RAM, e em disco
Como fazer composição de uma forma limpa
Estrutura de codigos mais organizadas
Instanciamento de objetos de uma forma mais centrada

🔮 Próximos passos

Mais consultas e metodos usando LINQ

Codigos mais limpos e simplificados

Criar API

👨‍💻 Autor

Kauan Santos

GitHub: https://github.com/kauansantts
