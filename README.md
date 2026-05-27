# Employee Management System — API

ASP.NET Core Web API for employee CRUD operations, built with .NET 6 and Entity Framework Core.

## Overview

RESTful backend that exposes endpoints to create, read, update, and delete employee records. Uses EF Core for data access with SQL Server.

## Features

- Full employee CRUD via REST API
- Entity Framework Core 6 with migrations
- Swagger/OpenAPI documentation
- Docker support
- SQL Server database

## Tech Stack

- **.NET 6** / ASP.NET Core Web API
- **Entity Framework Core 6**
- **SQL Server**
- **Swagger** (Swashbuckle)

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server

### Run

```bash
git clone https://github.com/Kezara666/EMPMSAPI.git
cd EMPMSAPI/EMPMS-API
dotnet restore
dotnet ef database update
dotnet run
```

Open Swagger at `https://localhost:5001/swagger`.

## Screenshots

![API Swagger UI](https://github.com/user-attachments/assets/83e67f54-6416-4943-aeb3-b60e707d1768)

## Related

Frontend companion: [EmsFrontend](https://github.com/Kezara666/EmsFrontend)

## Author

Kezara Lakshan — [GitHub](https://github.com/Kezara666)
