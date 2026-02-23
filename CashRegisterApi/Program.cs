using Repository;
using UseCase.Services;
using UseCase.UseCases;
using UseCase.UseCases.Mapping.User;

var builder = WebApplication.CreateBuilder(args);

// --- 1. SEÇÃO DE SERVIÇOS (Injeção de Dependência) ---

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddUseCase();

builder.Services.ConfigurationServices();

// Adiciona o ApiExplorer, necessário para descobrir os endpoints da sua API
builder.Services.AddEndpointsApiExplorer();

// Configura o gerador do Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- 2. SEÇÃO DE MIDDLEWARE (Pipeline HTTP) ---

// Habilita o Swagger apenas em ambiente de Desenvolvimento por segurança
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();