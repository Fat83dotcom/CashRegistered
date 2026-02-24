using System.Net;
using System.Text.Json;
using Shared.Exceptions;

namespace CashRegister.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Tenta seguir o fluxo normal da API (Controllers, UseCases, etc)
            await _next(context);
        }
        catch (DomainException ex)
        {
            // Se em qualquer lugar estourar uma BaseException, ele cai aqui!
            await HandleDomainExceptionAsync(context, ex);
        }
        // catch (Exception ex)
        // {
        //     // Aqui você pode tratar erros genéricos (Erro 500)
        //     await HandleGenericExceptionAsync(context, ex);
        // }
    }

    private static Task HandleDomainExceptionAsync(HttpContext context, BaseException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var response = new
        {
            Type = ex.GetType().Name,
            Message = ex.Message,
            ex.Errors // Pega a lista de erros que veio do seu ValueObject
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static Task HandleGenericExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // Retorna 500

        var response = new
        {
            Type = "InternalServerError",
            Message = ex.Message
            // Detalhes do erro original omitidos por segurança em produção
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}