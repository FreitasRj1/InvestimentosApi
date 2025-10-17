# InvestimentosApi

API para gerenciamento de investimentos (CRUD) e **integração com API pública ViaCEP** — projeto desenvolvido em C# (.NET 9), com arquitetura em camadas.

## 🎯 Objetivo
O objetivo do projeto é **criar uma API RESTful** para manipulação de dados financeiros e consultar informações de endereço a partir de CEPs, de forma simples e organizada.  
A aplicação foi projetada para atender requisitos de **estruturação de classes**, **integração com API externa**, **conexão com banco de dados**, **manipulação de arquivos** e **boas práticas de código limpo**.

## 👥 Grupo

- **Gabriel Freitas** – RM550187  
- **Gabriel Toledo** – RM551654  
- **Guilherme Daher** – RM98611  
- **Gustavo Akio** – RM550241  
- **Heitor Nobre** – RM551539  

## 🧩 Arquitetura
- `InvestimentosApi` — API (Controllers)  
- `InvestimentosBusiness` — Serviços / Regra de negócio  
- `InvestimentosData` — EF Core `ApplicationDbContext`, Migrations  
- `InvestimentosModel` — Entidades  
- `InvestimentosService` — Integração externa (ViaCEP)

## ⚙️ Funcionalidades

- **CRUD Completo de Investimentos**  
  - Criar (POST)  
  - Consultar todos e por ID (GET)  
  - Atualizar (PUT)  
  - Deletar (DELETE)  

- **Consulta de CEP via API pública (ViaCEP)**  
  - Permite obter endereço completo a partir de um CEP informado  
  - Endpoint consumido: `https://viacep.com.br/ws/{cep}/json/`

- **Persistência em Banco de Dados** usando **Entity Framework Core**  

- **Manipulação de Arquivos** (JSON/TXT) para exportação ou backup de dados  

- **Interface via Console** para facilitar interação e testes locais  

- **Documentação das rotas** via Swagger (`/swagger`) e arquivo `InvestimentosApi.http`  

## 🌐 Exemplo de Consulta de CEP

**Requisição:**

---

### ✅ Resumo das mudanças feitas:
- Adicionamos **integração ViaCEP** nas funcionalidades e objetivo.  
- Criamos uma nova camada `InvestimentosService` na arquitetura.  
- Incluímos **exemplo de requisição e resposta** da API pública.  
- Mencionamos o **diagrama no draw.io**.  

### ⚙️ Instalação e execução local 1. Clone o repositório:
bash
git clone https://github.com/FreitasRj1/InvestimentosApi.git
cd InvestimentosApi


