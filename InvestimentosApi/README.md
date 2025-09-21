# InvestimentosApi

API para gerenciamento de investimentos (CRUD) — projeto desenvolvido em C# (.NET 9), com arquitetura em camadas.

## Arquitetura
- `InvestimentosApi` — API (Controllers)
- `InvestimentosBusiness` — Serviços/Regra de negócio
- `InvestimentosData` — EF Core `ApplicationDbContext`, Migrations
- `InvestimentosModel` — Entidades

## Pré-requisitos
- .NET 9 SDK
- Oracle Database (XE) ou outro SGBD configurado
- (Opcional) Postman ou VS Code REST Client

## Instalação e execução local
1. Clone o repositório:
```bash
git clone https://github.com/FreitasRj1/InvestimentosApi.git
cd InvestimentosApi
