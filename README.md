# InvestimentosApi

API para gerenciamento de investimentos (CRUD) — projeto desenvolvido em C# (.NET 9), com arquitetura em camadas.

##  Objetivo
O objetivo do projeto é **criar uma API RESTful** para manipulação de dados financeiros de forma simples e organizada.  
A aplicação foi projetada para atender requisitos de **estruturação de classes**, **conexão com banco de dados**, **manipulação de arquivos** e **boas práticas de código limpo**.

## Grupo

- **Gabriel Freitas** – RM550187  
- **Gabriel Toledo** – RM551654  
- **Guilherme Daher** – RM98611  
- **Gustavo Akio** – RM550241  
- **Heitor Nobre** – RM551539  


## Arquitetura
- `InvestimentosApi` — API (Controllers)
- `InvestimentosBusiness` — Serviços/Regra de negócio
- `InvestimentosData` — EF Core `ApplicationDbContext`, Migrations
- `InvestimentosModel` — Entidades


## Funcionalidades

- **CRUD Completo de Investimentos**  
  - Criar (POST)  
  - Consultar todos e por ID (GET)  
  - Atualizar (PUT)  
  - Deletar (DELETE)  

- **Persistência em Banco de Dados** usando **Entity Framework Core**  

- **Manipulação de Arquivos** (JSON/TXT) para exportação ou backup de dados  

- **Interface via Console** para facilitar interação e testes locais  

- **Documentação das rotas** via arquivo `InvestimentosApi.http` e suporte ao Postman  


### ⚙️ Instalação e execução local
1. Clone o repositório:
```bash
git clone https://github.com/FreitasRj1/InvestimentosApi.git
cd InvestimentosApi