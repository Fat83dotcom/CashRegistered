using Application;
using Application.Services;
using Application.Identity.UseCases;
using Application.Security.UseCases;
using Application.Financial.UseCases;
using CashRegister.Middlewares;
using CashRegisterApi.Middlewares;
using Infrastructure;

using CashRegisterApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// --- 1. SEÇÃO DE SERVIÇOS (Injeção de Dependência) ---

builder.Services.AddControllers(options =>
{
    options.Filters.Add<NotificationFilter>();
});

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddUseCase();

builder.Services.ConfigurationServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowFront", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // A porta do seu React
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allowFront");

app.UseAuthentication();
    
app.UseAuthorization();

app.MapControllers();

app.Run();