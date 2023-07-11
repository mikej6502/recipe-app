using Microsoft.AspNetCore.Mvc;

namespace RecipeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheckController : ControllerBase
{
    private readonly ILogger<HealthCheckController> _logger;

    public HealthCheckController(ILogger<HealthCheckController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult CheckHealth()
    {
        _logger.LogInformation("Health Check");
        return Ok();
    }
}