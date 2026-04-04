# API Layer - Backend

The entry point of the ASP.NET Core application.

## Responsibilities
- **Controllers:** Exposing REST endpoints (`AuthController`, `CashFlowController`, etc.).
- **Middlewares:** Handling cross-cutting concerns (e.g., `ExceptionHandlingMiddleware`).
- **Program.cs:** Application configuration, DI registration, and middleware pipeline.
- **Appsettings:** Configuration settings for different environments.

## Guidelines for Gemini
- Keep Controllers thin. Most logic should reside in the Application layer.
- Use `ActionResult<T>` for consistent API responses.
- Ensure proper use of HTTP verbs (GET, POST, PUT, DELETE).
- Verify CORS and authentication settings in `Program.cs` when changing frontend/backend interaction.
- não use repository nos controllers