// Configura��o do Builder

using DemoInicialASPNET;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do Pipeline

// Middlewares

// Services 


// Configura��o da App

var app = builder.Build();

// Configura��o de Comportamentos da App
app.UseMiddleware<LogTempoMiddleware>();

app.MapGet("/", () => "Hello World!");

app.MapGet("/teste", () =>
{
    // Colocando a requisi��o para "dormir"
    Thread.Sleep(1500);

    return "Teste de Sleep";
});

app.Run();
