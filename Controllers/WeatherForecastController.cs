using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace appSettingsSample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IOptions<AppConfig> _appConfiguration;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<AppConfig> appConfiguration)
    {
        _logger = logger;
        _appConfiguration = appConfiguration;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        // Log the appConfig values to see what we're getting from appSettings.json
        _logger.LogInformation($"Environment: {_appConfiguration.Value.AppEnvironment}, Version: {_appConfiguration.Value.AppVersion}, Name: {_appConfiguration.Value.AppName}");
        
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
        })
        .ToArray();
    }
}
