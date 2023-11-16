using Serilog;
using System.Diagnostics;

namespace DemoInicialASPNET
{
    public class TemplateMiddleware
    {
        // Tipo de atributo que realiza uma chamada e fica esperando o retorno dela
        private readonly RequestDelegate _next;

        public TemplateMiddleware(RequestDelegate next) { _next = next; }

        // O objeto HttpContext contém todas as informações de uma solicitação HTTP (request ou response)
        public async Task InvokeAsync(HttpContext httpContext)
        {
            // Realiza uma lógica de programação antes

            // Chama o próximo middleware no pipeline
            await _next(httpContext);

            // Realiza uma lógica de programação depois
        }
    }

    public class LogTempoMiddleware
    {
        private readonly RequestDelegate _next;

        public LogTempoMiddleware(RequestDelegate next) { _next = next; }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var sw = Stopwatch.StartNew();


            await _next(httpContext);


            sw.Stop();

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            Log.Information($"A execução demorou {sw.Elapsed.TotalMilliseconds}ms ({sw.Elapsed.TotalSeconds} segundos)");
        }
    }
}