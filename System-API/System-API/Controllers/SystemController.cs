using Microsoft.AspNetCore.Mvc;
using SystemA_API.Models;

namespace SystemA_API.Controllers;

[ApiController]
[Route("[controller]")]
public class SystemController : ControllerBase
{
    private readonly IEngineeringSystem _system;
    private readonly ILogger<SystemController> _logger;

    public SystemController(ILogger<SystemController> logger, IEngineeringSystem system)
    {
        _logger = logger;
        _system = system;
    }

    [HttpGet("/system/info")]
    public async Task<IActionResult> Get()
    {
        return Ok(_system);
    }
}