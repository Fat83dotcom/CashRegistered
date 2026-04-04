# Shared Layer - Backend

The Shared kernel contains common abstractions used across multiple layers.

## Responsibilities
- **Abstractions:** `BaseEntity`, `IRepository`, `IUnitOfWork`.
- **Exceptions:** Base exception classes (`BaseException`, `DomainException`).
- **Request/Response:** Common data structures for API interactions.
- **Value Objects/Validations:** Utility classes for domain logic.

## Guidelines for Gemini
- Keep the Shared layer minimal. Only truly cross-cutting code should reside here.
- Avoid introducing business logic that belongs in the `Domain` layer.
- Ensure base classes are flexible enough to support all current and future entities.
