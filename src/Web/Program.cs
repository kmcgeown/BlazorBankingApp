using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<AuthStateService>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
builder.Services.AddProviders();

var app = builder.Build();

var loggerConfig = new LoggerConfiguration();
var grafanaLabels = new List<LokiLabel>
{
    new() { Key = "application", Value = "bankapp" },
    new() { Key = "environment", Value = app.Environment.EnvironmentName },
};

loggerConfig
    .MinimumLevel.Information()
    .Enrich.FromGlobalLogContext()
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .Enrich.WithEnvironmentName()
    .WriteTo.GrafanaLoki(builder.Configuration.GetValue<string>("LokiServer")!, grafanaLabels)
    .WriteTo.Async(a =>
        a.File(
            new CompactJsonFormatter(),
            "..logs/bankapp-.json",
            rollingInterval: RollingInterval.Day
        )
    )
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting.Diagnostics", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.Extensions.Http.Resilence", LogEventLevel.Warning);

var logger = loggerConfig.CreateLogger();
var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
loggerFactory.AddSerilog(logger);

TimeLogger.Logger = app.Logger;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();

public static partial class Program { } //For intregation tests visiblity 
