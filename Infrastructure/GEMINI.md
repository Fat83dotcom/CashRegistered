# Infrastructure Layer - Backend

The Infrastructure layer handles concerns external to the application logic.

## Responsibilities
- **Persistence:** Entity Framework Core configuration (`CashRegisterDbContext`) and Migrations.
- **Repositories:** Concrete implementations of `Domain.Interfaces` (e.g., `CashFlowRepository`).
- **Security:** Implementation of security services (e.g., `Argon2Services` for password hashing).
- **Dependency Injection:** Wiring up infrastructure components in `DependecyInjectionInfrastructure.cs`.

## Guidelines for Gemini
- Use Fluent API for entity configurations in `Configurations/`.
- Ensure repositories use `IUnitOfWork` for transactional integrity when needed.
- Maintain EF Core migrations when updating domain entities.
- Abstract sensitive operations behind domain interfaces.
