# Backend - Cash Register System

This directory contains the backend of the Cash Register system, built with ASP.NET Core and following Clean Architecture.

## Projects
- **Domain:** Core business logic (Entities, Interfaces).
- **Application:** Use cases and orchestration logic.
- **Infrastructure:** External concerns (Persistence, Security).
- **CashRegisterApi:** Entry point (Controllers, Middlewares).
- **Shared:** Common abstractions and utilities.

## Technical Details
- **Language:** C#
- **Framework:** ASP.NET Core 10.0 (as seen in .csproj files).
- **ORM:** Entity Framework Core.
- **Security:** Argon2 for password hashing.

## Guidelines for Gemini
- Maintain strict separation of concerns between layers.
- Business rules belong in the `Domain` or `Application` layers.
- Do not add infrastructure dependencies to the `Domain` layer.
- Use `Shared` for cross-cutting abstractions.
