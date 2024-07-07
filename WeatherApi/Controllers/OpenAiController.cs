using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController : ControllerBase
{
    private readonly ILogger<OpenAiController> _logger;
    public OpenAiController(ILogger<OpenAiController> logger)
    {
            _logger = logger;
    }
    
    [HttpGet]
    public async Task Get()
    {
        await Task.Delay(110);
        _logger.LogDebug("Getting OpenAPI model.");
        // Implement the logic to return the OpenAPI specification
        
    }
}