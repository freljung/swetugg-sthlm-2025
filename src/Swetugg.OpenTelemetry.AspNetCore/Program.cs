var builder = WebApplication.CreateBuilder(args);

#region 1 Initial tracing and metrics setup

//builder.Services.AddOpenTelemetry()
//    .ConfigureResource(resource => resource.AddService(
//        serviceName: builder.Environment.ApplicationName,
//        serviceVersion: "1.0.0",
//        serviceInstanceId: "my-awesome-laptop"))

//    .WithTracing(tracing =>
//    {
//        tracing
//            .AddAspNetCoreInstrumentation()
//            .AddHttpClientInstrumentation()
//            .AddOtlpExporter(options =>
//            {
//                options.Endpoint = new Uri("https://otlp-gateway-prod-eu-north-0.grafana.net/otlp/v1/traces");
//                options.Protocol = OtlpExportProtocol.HttpProtobuf;
//                options.Headers = builder.Configuration["Otlp:Headers"];
//            })
//            .AddConsoleExporter(config => config.Targets = ConsoleExporterOutputTargets.Debug);
//    })

//    .WithMetrics(metrics =>
//    {
//        metrics
//            .AddAspNetCoreInstrumentation()
//            .AddHttpClientInstrumentation()
//            .AddRuntimeInstrumentation()
//            .AddOtlpExporter(options =>
//            {
//                options.Endpoint = new Uri("https://otlp-gateway-prod-eu-north-0.grafana.net/otlp/v1/metrics");
//                options.Protocol = OtlpExportProtocol.HttpProtobuf;
//                options.Headers = builder.Configuration["Otlp:Headers"];
//            })
//            .AddConsoleExporter(config => config.Targets = ConsoleExporterOutputTargets.Debug);
//    });

//builder.Services.AddHttpClient();

#endregion

#region 2 Traces
//
// 2. Traces
//
//Instrumentation.Initialize(builder);

//builder.Services.AddSingleton(new Instrumentation());

//// Add services to the container.
//builder.Services.AddOpenTelemetry()
//    .ConfigureResource(resource => resource.AddService(
//        serviceName: Instrumentation.ServiceName,
//        serviceVersion: Instrumentation.ServiceVersion,
//        serviceInstanceId: "my-awesome-laptop"))

//.WithTracing(tracing =>
//{
//    tracing
//        .AddSource(Instrumentation.ServiceName)
//        .AddAspNetCoreInstrumentation()
//        .AddHttpClientInstrumentation()
//        .AddOtlpExporter(options =>
//        {
//            options.Endpoint = new Uri("https://otlp-gateway-prod-eu-north-0.grafana.net/otlp/v1/traces");
//            options.Protocol = OtlpExportProtocol.HttpProtobuf;
//            options.Headers = builder.Configuration["Otlp:Headers"];
//        })
//        .AddConsoleExporter(config => config.Targets = ConsoleExporterOutputTargets.Debug);
//})
//.WithMetrics(metrics =>
//{
//    metrics
//        .AddAspNetCoreInstrumentation()
//        .AddHttpClientInstrumentation()
//        .AddRuntimeInstrumentation()
//        .AddOtlpExporter(options =>
//        {
//            options.Endpoint = new Uri("https://otlp-gateway-prod-eu-north-0.grafana.net/otlp/v1/metrics");
//            options.Protocol = OtlpExportProtocol.HttpProtobuf;
//            options.Headers = builder.Configuration["Otlp:Headers"];
//        })
//        .AddConsoleExporter(config => config.Targets = ConsoleExporterOutputTargets.Debug);
//});

//builder.Services.AddHttpClient();

#endregion

#region 3 Metrics
//
// 3. Metrics
//
//Instrumentation.Initialize(builder);

//builder.Services.AddSingleton(new Instrumentation());

//// Add services to the container.
//builder.Services.AddOpenTelemetry()
//    .ConfigureResource(resource => resource.AddService(
//        serviceName: Instrumentation.ServiceName,
//        serviceVersion: Instrumentation.ServiceVersion,
//        serviceInstanceId: "my-awesome-laptop"))

//.WithTracing(tracing =>
//{
//    tracing
//        .AddSource(Instrumentation.ServiceName)
//        .AddAspNetCoreInstrumentation()
//        .AddHttpClientInstrumentation()
//        .AddOtlpExporter(options =>
//        {
//            options.Endpoint = new Uri("https://otlp-gateway-prod-eu-north-0.grafana.net/otlp/v1/traces");
//            options.Protocol = OtlpExportProtocol.HttpProtobuf;
//            options.Headers = builder.Configuration["Otlp:Headers"];
//        })
//        .AddConsoleExporter(config => config.Targets = ConsoleExporterOutputTargets.Debug);
//})
//.WithMetrics(metrics =>
//{
//    metrics
//        .AddMeter(Instrumentation.ServiceName)
//        .AddAspNetCoreInstrumentation()
//        .AddHttpClientInstrumentation()
//        .AddRuntimeInstrumentation()
//        .AddOtlpExporter(options =>
//        {
//            options.Endpoint = new Uri("https://otlp-gateway-prod-eu-north-0.grafana.net/otlp/v1/metrics");
//            options.Protocol = OtlpExportProtocol.HttpProtobuf;
//            options.Headers = builder.Configuration["Otlp:Headers"];
//        })
//        .AddConsoleExporter(config => config.Targets = ConsoleExporterOutputTargets.Debug);
//});

//builder.Services.AddHttpClient();

#endregion

#region 4 Logging
//
// 4. Logging
//
//Instrumentation.Initialize(builder);

//builder.Services.AddSingleton(new Instrumentation());

//// Add services to the container.
//builder.Services.AddOpenTelemetry()
//    .ConfigureResource(resource => resource.AddService(
//        serviceName: Instrumentation.ServiceName,
//        serviceVersion: Instrumentation.ServiceVersion,
//        serviceInstanceId: "my-awesome-laptop"))

//.WithTracing(tracing =>
//{
//    tracing
//        .AddSource(Instrumentation.ServiceName)
//        .AddAspNetCoreInstrumentation()
//        .AddHttpClientInstrumentation()
//        .AddOtlpExporter(options =>
//        {
//            options.Endpoint = new Uri("https://otlp-gateway-prod-eu-north-0.grafana.net/otlp/v1/traces");
//            options.Protocol = OtlpExportProtocol.HttpProtobuf;
//            options.Headers = builder.Configuration["Otlp:Headers"];
//        })
//        .AddConsoleExporter(config => config.Targets = ConsoleExporterOutputTargets.Debug);
//})
//.WithMetrics(metrics =>
//{
//    metrics
//        .AddMeter(Instrumentation.ServiceName)
//        .AddAspNetCoreInstrumentation()
//        .AddHttpClientInstrumentation()
//        .AddRuntimeInstrumentation()
//        .AddOtlpExporter(options =>
//        {
//            options.Endpoint = new Uri("https://otlp-gateway-prod-eu-north-0.grafana.net/otlp/v1/metrics");
//            options.Protocol = OtlpExportProtocol.HttpProtobuf;
//            options.Headers = builder.Configuration["Otlp:Headers"];
//        })
//        .AddConsoleExporter(config => config.Targets = ConsoleExporterOutputTargets.Debug);
//})

//.WithLogging(logging =>
//{
//    logging.AddOtlpExporter(options =>
//    {
//        options.Endpoint = new Uri("https://otlp-gateway-prod-eu-north-0.grafana.net/otlp/v1/logs");
//        options.Protocol = OtlpExportProtocol.HttpProtobuf;
//        options.Headers = builder.Configuration["Otlp:Headers"];
//    })
//    .AddConsoleExporter(config => config.Targets = ConsoleExporterOutputTargets.Debug);
//},
//    configureOptions: options =>
//    {
//        options.IncludeScopes = true;
//        options.IncludeFormattedMessage = true;
//    });
//builder.Services.AddHttpClient();

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
