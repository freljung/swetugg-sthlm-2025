using Microsoft.AspNetCore.Mvc;

namespace Swetugg.OpenTelemetry.AspNetCore.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(
    IHttpClientFactory httpClientFactory,
    Instrumentation instrumentation,
    ILogger<WeatherForecastController> logger)
    : ControllerBase
{
    private const string WeatherForecastActivityName = "Predict Weather";

    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    private IEnumerable<WeatherForecast> PredictWeather() =>
        Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();


    #region 1 Initial tracing
    //[HttpGet(Name = "GetWeatherForecast")]
    //public async Task<IEnumerable<WeatherForecast>> Get()
    //{
    //    var client = httpClientFactory.CreateClient();
    //    _ = await client.GetAsync("https://www.swetugg.se");

    //    return PredictWeather();
    //}
    #endregion

    #region 2 Traces
    //[HttpGet(Name = "GetWeatherForecast")]
    //public async Task<IEnumerable<WeatherForecast>> Get()
    //{
    //    using var activity = instrumentation.ActivitySource
    //        .StartActivity(name: WeatherForecastActivityName,
    //                       kind: ActivityKind.Client);
    //    activity!.AddTag("Forecast date", DateTime.Now.ToString());
    //    activity.AddEvent(
    //        new ActivityEvent("Getting weather forecast for {date}",
    //        tags: new ActivityTagsCollection { ["date"] = DateTime.Now.ToString() }));

    //    var client = httpClientFactory.CreateClient();
    //    _ = await client.GetAsync("https://www.swetugg.se");

    //    var result = PredictWeather();

    //    activity.SetStatus(ActivityStatusCode.Ok);
    //    return result;
    //}
    #endregion

    #region 3 Metrics
    //[HttpGet(Name = "GetWeatherForecast")]
    //public async Task<IEnumerable<WeatherForecast>> Get()
    //{
    //    using var activity = instrumentation.ActivitySource
    //        .StartActivity(WeatherForecastActivityName);

    //    activity.AddTag("Forecast Date", DateTime.Now.ToString());
    //    activity.AddEvent(new ActivityEvent("Getting weather forecast"));

    //    var client = httpClientFactory.CreateClient();
    //    _ = await client.GetAsync("https://www.swetugg.se");

    //    var result = PredictWeather();

    //    instrumentation.FreezingDaysCounter
    //        .Add(result.Count(f => f.Summary == "Freezing"));
    //    instrumentation.NonFreezingDaysCounter
    //        .Add(result.Count(f => f.Summary != "Freezing"));
    //    instrumentation.ColdDaysGauge
    //        .Record(result.Count(f => f.TemperatureC <= 0));

    //    foreach (var forecast in result)
    //    {
    //        instrumentation.TemperatureHistogram
    //            .Record(forecast.TemperatureC);
    //    }

    //    return result;
    //}
    #endregion

    #region 4 Logs
    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var result = PredictWeather();

        logger.TheFirstForecast(result.First());

        using var activity = instrumentation.ActivitySource.StartActivity(WeatherForecastActivityName);
        using var loggerScope = logger.BeginScope(
            new Dictionary<string, object?>
            {
                ["MyAttribute"] = "Some Attribute!",
                ["Forecast Date"] = DateTime.Now
            });

        var client = httpClientFactory.CreateClient();
        _ = await client.GetAsync("https://www.swetugg.se");

        logger.TheFirstForecast(result.First());

        return result;
    }
    #endregion
}

#region 4 Logs
//public static partial class WeatherForecastLogs
//{
//    [LoggerMessage(1, LogLevel.Information, "Returning weather forecast for day {weatherForecast}")]
//    public static partial void TheFirstForecast(
//        this ILogger logger,
//        [LogProperties(OmitReferenceName = true)] WeatherForecast weatherForecast);
//}
#endregion