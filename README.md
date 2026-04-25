# CQRSOrderManagement

A simple order-management web API built around the CQRS pattern in ASP.NET Core, with a hand-rolled command/query dispatcher (no MediatR) and JWT auth.

## Stack

- .NET 8 / ASP.NET Core
- EF Core + SQL Server
- BCrypt + JWT bearer auth
- Swashbuckle for the API explorer

## Layout

- `Models/` — request/response DTOs grouped by feature (`Auth/`, `Order/`)
- `Implements/Dispatchers` + `Implements/Handlers` — the CQRS plumbing
- `Controllers/` — thin endpoints that dispatch to the right handler
- `Entities/` — EF Core entity types (`Order`, `User`)

## Running

```bash
# Update appsettings.json with your SQL Server connection + JWT settings
dotnet ef database update
dotnet run
```

Swagger UI is exposed at `/swagger` while running.
