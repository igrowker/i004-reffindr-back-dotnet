namespace Reffindr.Api.Middleware;

public class MetricsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly MetricsService _metricsService;

    public MetricsMiddleware(RequestDelegate next, MetricsService metricsService)
    {
        _next = next;
        _metricsService = metricsService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            await _next(context);
            stopwatch.Stop();

            _metricsService.IncrementHttpRequests(
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode.ToString());

            _metricsService.ObserveHttpRequestDuration(
                context.Request.Method,
                context.Request.Path,
                stopwatch.Elapsed.TotalSeconds);
        }
        catch (Exception)
        {
            stopwatch.Stop();

            _metricsService.IncrementHttpErrors(
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode.ToString());
            throw;
        }
    }
}