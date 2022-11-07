using Microsoft.AspNetCore.Mvc;
using SystemA_API.Models;
using SystemA_API.Services;

namespace SystemA_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ModelController : ControllerBase
{
    private readonly IEngineeringSystem _system;
    private readonly IMessagingService _messagingService;
    private readonly ILogger<ModelController> _logger;

    public ModelController(ILogger<ModelController> logger, IEngineeringSystem system, IMessagingService messagingService)
    {
        _logger = logger;
        _system = system;
        _messagingService = messagingService;
    }

    [HttpGet("/models")]
    public IActionResult Get()
    {
        return Ok(_system.Models);
    }

    [HttpGet("/models/{id}")]
    public IActionResult GetModel(string id)
    {
        var model = _system.Models.FirstOrDefault(m => m.Id == id);
        if (model == null)
            return NotFound();

        return Ok(model);
    }

    [HttpPost("/models")]
    public IActionResult CreateModel(EngineeringModel engineeringModel)
    {
        if (_system.Models.Any(m => m.Id == engineeringModel.Id))
            return BadRequest();

        _system.Models.Add(engineeringModel);
        _messagingService.PublishUpdated(engineeringModel);

        return Ok();
    }

    [HttpPut("/models/{id}")]
    public IActionResult UpdateModel(string id, EngineeringModel engineeringModel)
    {
        var model = _system.Models.FirstOrDefault(m => m.Id == id);
        if (model == null)
            return NotFound();

        model.Contains = engineeringModel.Contains;
        _messagingService.PublishUpdated(model);

        return Ok(model);
    }
    
    [HttpDelete("/models/{id}")]
    public IActionResult DeleteModel(string id)
    {
        var modelDeleted = _system.Models.FirstOrDefault(m => m.Id == id);
        if (modelDeleted == null)
            return Ok();
        
        _system.Models = new List<EngineeringModel>(_system.Models.Where(m => m.Id != id));
        _messagingService.PublishUpdated(modelDeleted);
        
        return Ok();
    }
}