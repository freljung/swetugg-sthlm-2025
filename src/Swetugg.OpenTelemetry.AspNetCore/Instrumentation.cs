using System.Diagnostics.Metrics;

public class Instrumentation : IDisposable
{
    public static string ServiceName { get; private set; }
    public static string ServiceVersion { get; private set; }

    public ActivitySource ActivitySource { get; }

    #region 3 Metrics
    public Counter<long> FreezingDaysCounter { get; }
    public Counter<long> NonFreezingDaysCounter { get; }
    public Gauge<int> ColdDaysGauge { get; }
    public Histogram<int> TemperatureHistogram { get; }

    private readonly Meter meter;
    #endregion

    public Instrumentation()
    {
        ActivitySource = new ActivitySource(ServiceName, ServiceVersion);

        #region 3 Metrics
        meter = new Meter(ServiceName, ServiceVersion);
        FreezingDaysCounter = meter.CreateCounter<long>("weather.days.freezing", description: "The number of days where the temperature is below freezing");
        NonFreezingDaysCounter = meter.CreateCounter<long>("weather.days.nonfreezing", description: "The number of days where the temperature is not freezing");
        ColdDaysGauge = meter.CreateGauge<int>("weather.days.cold", description: "The number of days where the temperature is cold");
        TemperatureHistogram = meter.CreateHistogram<int>("weather.temperature", description: "The distribution of temperatures",
            advice: new InstrumentAdvice<int> 
            { 
                HistogramBucketBoundaries = [-20, 0, 10, 20, 30, 40, 55]
            });
        #endregion
    }

    public void Dispose()
    {
        ActivitySource?.Dispose();

        #region 3 Metrics
        meter?.Dispose();
        #endregion
    }

    public static void Initialize(WebApplicationBuilder builder)
    {
        ServiceName = builder.Environment.ApplicationName;
        ServiceVersion = typeof(Instrumentation).Assembly.GetName().Version?.ToString() ?? "1.0.0";
    }
}