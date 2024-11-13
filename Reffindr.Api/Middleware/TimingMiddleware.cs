using System.Diagnostics;

namespace Reffindr.Api.Middleware;

public class TimingMiddleware
{
    private readonly RequestDelegate _next;

    public TimingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        await _next(context);

        stopwatch.Stop();
        Console.WriteLine($"Tiempo de ejecución de la solicitud: {stopwatch.ElapsedMilliseconds} ms");
    }
}
