using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;

const string ActivitySourceName = "TestActivitySource";

var builder = Host.CreateApplicationBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddOpenTelemetry().WithTracing(tracing => tracing.AddSource(ActivitySourceName));
var app = builder.Build();

using var activitySource = new ActivitySource(ActivitySourceName);
using var tracerProvider = app.Services.GetRequiredService<TracerProvider>(); // required for traces to work
var logger = app.Services.GetRequiredService<ILogger<Program>>();

long count = 0L;
while (true)
{
    using var activity = activitySource.StartActivity("test.activity", ActivityKind.Internal, parentId: null, tags: [new("test.count", count)]);
    logger.LogInformation("Test # {Count}", count);

    if (count >= 10_000 && count % 100 == 0)
    {
        using var subActivity = activitySource.StartActivity("test.meaningful_activity");
        logger.LogInformation("Meaningful test # {Count}", count);
        await Task.Delay(20);
    }
    count++;
}

partial class Program { }
