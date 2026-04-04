# Domain Layer - Backend

The core of the system, containing business entities and their logic.

## Responsibilities
- **Entities:** Rich domain models (e.g., `User`, `CashFlow`, `Expense`).
- **Enums:** Domain-specific enumerations (e.g., `UserRole`, `Gender`).
- **Value Objects:** Simple types without identity (e.g., `Address`).
- **Interfaces:** Definitions for repositories and services (e.g., `ICashFlowRepository`).
- **Validations:** Business rules and domain constraints.

## Guidelines for Gemini
- Domain entities should be self-validating (e.g., using `Validate` method in constructor).
- This layer MUST have no dependencies on external frameworks or other layers (except `Shared`).
- Use `BaseEntity` from `Shared.Abstractions` for all entities.
- Keep business logic inside the Domain whenever possible (Domain-Driven Design).
- nos use case, não use repositorios cruzados, por exemplo, se dentro de user vc tiver que chamar uma funçionalidade de person, chame seu use case correspondente