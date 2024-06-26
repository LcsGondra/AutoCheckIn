# ATENÇÃO 

ESSE PROJETO TRABALHA EM CONJUNTO COM ESSE OUTRO PROJETO, LEMBRE DE USAR OS DOIS AO MESMO TEMPO PARA TER A EXPERIENCIA COMPLETA

- **FRONT-END**: https://github.com/LcsGondra/AutoCheckIn-Front-Vite
- **BACK-END**: https://github.com/LcsGondra/AutoCheckIn/

# AutoCheckIn - Backend em C# .NET 8

Este repositório contém o backend para o projeto AutoCheckIn, desenvolvido em C# com o framework .NET 8. O AutoCheckIn é um sistema que facilita o processo de check-in em hospitais, utilizando informações preenchidas pelos pacientes.

## Estrutura do Projeto

O projeto está estruturado da seguinte forma:

```
AutoCheckInSolution/
│
├── AutoCheckIn.API/ # Projeto da API HTTP
│
├── AutoCheckIn.App/ # Projeto de aplicação (contém a lógica de negócios)
│
├── AutoCheckIn.Domain/ # Projeto de Classes
│
└── AutoCheckIn.Repo/ # Projeto de infraestrutura (repositório/Acesso a banco de dados futuramente)
```

## Funcionalidades da API

### Endpoints Disponíveis

- **GET /api/CheckIn**: Retorna informações sobre o check-in.
- **GET /api/Hospital/All**: Retorna todos os hospitais cadastrados.
- **POST /api/Paciente**: Registra um novo paciente.

## Configuração e Execução

1. **Pré-requisitos**:
   - SDK .NET 8.0 ou superior
   - Visual Studio 2022

2. **Clonando e Executando o Projeto**:

   ```bash
   git clone https://github.com/LcsGondra/AutoCheckIn.git
   ```
   ```bash
   cd AutoCheckIn/AutoCheckIn.API
   ```
   ```bash
   dotnet run
   ```
3. **Abrindo pelo Visual Studio**
   Caso prefica basta abrir a solucao usando o visual studio 2022 e apertando f5 ou ctrl f5 para rodar o projeto ou usando a interface:
   ![start-button](https://github.com/LcsGondra/AutoCheckIn/assets/96592652/b7f099e0-74ca-4daf-8b34-d9e10ef8480c)


A API estará disponível em http://localhost:5072

pode acessar swagger usando:
http://localhost:5072/swagger/index.html

