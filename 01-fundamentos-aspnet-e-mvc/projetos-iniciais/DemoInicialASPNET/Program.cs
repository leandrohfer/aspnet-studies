using Serilog;

// Configuração do Builder
using DemoInicialASPNET;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Pipeline

// Middlewares

// Services 
builder.AddSerilog();

// Configuração da App

var app = builder.Build();

// Configuração de Comportamentos da App
app.UseLogTempo();

app.MapGet("/", () => "Hello World!");

app.MapGet("/teste", () =>
{
    // Colocando a requisição para "dormir"
    Thread.Sleep(1500);

    return "Teste de Sleep";
});

app.Run();
