# 📡 Comunica+

👥 Integrantes do Projeto
Bruno Da Silva Souza - RM: 94346

Julio Samuel De Oliveira - RM: 557453

Leonardo Da Silva Pereira - RM: 557598

> Solução para comunicação offline em situações de emergência, desenvolvida com .NET e Oracle. Ideal para locais com conectividade limitada.

---

## 📘 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Arquitetura e Camadas](#arquitetura-e-camadas)
- [Como Executar](#como-executar)
- [EndPoints da API](#endpoints-da-api)
- [Migrations e Banco de Dados](#migrations-e-banco-de-dados)

---

## 🧩 Sobre o Projeto

O **Comunica+** é uma API RESTful que gerencia dispositivos e mensagens para permitir comunicação offline. Ideal para uso em áreas remotas ou em emergências, quando o acesso à internet é restrito ou inexistente.

Funcionalidades:
- Cadastro, edição, exclusão e listagem de dispositivos.
- Envio e histórico de mensagens associadas a dispositivos.
- Integração com banco de dados Oracle.
- Documentação Swagger disponível.

---

## 🚀 Tecnologias Utilizadas

- **.NET 7 / .NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **Banco de Dados Oracle**
- **Swagger (Swashbuckle)**
- **Migrations EF Core**
- **Razor Pages com TagHelpers**

---

## 🧱 Arquitetura e Camadas

- `Controllers`: Controladores da API (`DevicesController`, `MessagesController`)
- `DTOs`: Objetos de transferência de dados (`DeviceDto`, `MessageDto`)
- `Services`: Regras de negócio implementadas via interfaces (`IDeviceService`, `IMessageService`)
- `Data`: Contexto de banco de dados (`AppDbContext`)
- `Models`: Modelos de domínio (`Device`, `Message`)
- `Migrations`: Controle de versão do banco via EF Core

---

## 🛠️ Como Executar

### Pré-requisitos

- .NET SDK
- Oracle Database (ou Oracle XE)
- Oracle Entity Framework Core Provider

### Passos

```bash
# 1. Restaurar os pacotes
dotnet restore

# 2. Aplicar as migrations ao banco de dados
dotnet ef database update

# 3. Executar a aplicação
dotnet run

# Acesse no navegador:
https://localhost:7276/swagger/index.html

🔗 EndPoints da API
A documentação completa da API pode ser acessada via Swagger:

👉 https://localhost:7276/swagger/index.html

🗃️ Migrations e Banco de Dados
As Migrations são gerenciadas pelo Entity Framework Core. Para gerar novas migrations:
```bash
dotnet ef migrations add NomeDaMigration
dotnet ef database update

## 📌 Exemplos de Uso

### ➕ Criar um Dispositivo

**POST** `/api/devices`

**Request:**
```json
{
  "deviceId": "string",
  "name": "string",
  "status": "string",
  "lastSeen": "2025-05-29T18:11:00.254Z"
}

Response:
```json
{
    "deviceId": "abc123",
    "name": "Bruno",
    "status": "Rua Pio XI",
    "lastSeen": "2025-05-29T18:15:14.058"
  }
```

📋 Listar Todos os Dispositivos
GET /api/devices

Response:
```json
[
  {
    "deviceId": "abc123",
    "name": "Bruno",
    "status": "Rua Pio XI",
    "lastSeen": "2025-05-29T18:15:14.058"
  }
]
```

📋 Editar Todos os Dispositivos
PUT /api/devices

Response:
```json
  {
  "deviceId": "abc123",
  "name": "Bruno Da Silva",
  "status": "Rua Pio XI",
  "lastSeen": "2025-05-29T18:18:36.517Z"
}
```

✉️ Enviar uma Mensagem
POST /api/messages

Request:
```json
{
  "sender": "string",
  "content": "string",
  "deviceId": "string",
  "timestamp": "2025-05-29T18:21:28.314Z"
}
```

Response:
```json
{
  "sender": "Chuva",
  "content": "Chuva Forte",
  "deviceId": "abc123",
  "timestamp": "2025-05-29T18:22:39.372Z"
}
```
---
