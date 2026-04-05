using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared.Notifications;

namespace CashRegisterApi.Filters;

public class NotificationFilter(NotificationContext notificationContext) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Executa a Action (o Controller e o Use Case)
        var executedContext = await next();

        // Após a execução, verifica se há notificações no contexto compartilhado
        if (notificationContext.IsInvalid)
        {
            var notifications = notificationContext.Notifications.Select(n => new 
            {
                Property = n.Key,
                Message = n.Message
            });

            // Substitui o resultado original (ex: 201 Created) por um 400 Bad Request
            executedContext.Result = new BadRequestObjectResult(new { errors = notifications });
        }
    }
}
