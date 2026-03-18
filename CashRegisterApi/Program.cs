using Application.Services;
using Application.UseCases;
using CashRegister.Middlewares;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// --- 1. SEÇÃO DE SERVIÇOS (Injeção de Dependência) ---

builder.Services.AddControllers();

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
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("allowFront");

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
    
app.UseAuthorization();

app.MapControllers();

app.Run();