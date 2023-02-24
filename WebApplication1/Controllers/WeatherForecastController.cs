using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace WebApplication1.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly MySqlConnection _mySqlConnection;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, MySqlConnection mySqlConnection)
    {
        _logger = logger;
        _mySqlConnection = mySqlConnection;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetAsync()
    {
            var result= await _mySqlConnection.QueryAsync("SELECT * FROM sms_provider_api.resource_status;");
        return Ok(result);
    }
}
