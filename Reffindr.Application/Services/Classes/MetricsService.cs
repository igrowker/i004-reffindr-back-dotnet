using Prometheus;
public class MetricsService
{
    private readonly Counter _httpRequestCounter = Metrics.CreateCounter(
        "http_requests_total",
        "Total number of HTTP requests",
        new CounterConfiguration
        {
            LabelNames = new[] { "method", "path", "status" }
        });

    private readonly Histogram _httpRequestDurationHistogram = Metrics.CreateHistogram(
        "http_request_duration_seconds",
        "Duration of HTTP requests in seconds",
        new HistogramConfiguration
        {
            LabelNames = new[] { "method", "path" },
            Buckets = Histogram.LinearBuckets(0.5, 1.0, 5)
        });

    private readonly Counter _httpErrorCounter = Metrics.CreateCounter(
        "http_errors_total",
        "Total number of HTTP errors",
        new CounterConfiguration
        {
            LabelNames = new[] { "method", "path", "status" }
        });

    public void IncrementHttpRequests(string method, string path, string status)
    {
        _httpRequestCounter.WithLabels(method, NormalizePath(path), status).Inc();
    }

    public void IncrementHttpErrors(string method, string path, string status)
    {
        _httpErrorCounter.WithLabels(method, NormalizePath(path), status).Inc();
    }

    public void ObserveHttpRequestDuration(string method, string path, double duration)
    {
        _httpRequestDurationHistogram.WithLabels(method, NormalizePath(path)).Observe(duration);
    }

    private string NormalizePath(string path)
    {
        return System.Text.RegularExpressions.Regex.Replace(path, @"\/\d+", "/:id");
    }
}