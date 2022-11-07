using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemA_API.Data;
using SystemA_API.Models;

namespace SystemA_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    private readonly ILogger<SystemController> _logger;
    private readonly DataContext _dbContext;

    public ValuesController(ILogger<SystemController> logger, DataContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var dataPoint = await _dbContext.DataPoints.FirstOrDefaultAsync(dp => dp.Id == id);
        if (dataPoint == null)
            return NotFound();
        
        return Ok(dataPoint);
    }

    [HttpPut("/{id}")]
    public async Task<IActionResult> Put(string id, [FromQuery] string value)
    {
        var dataPoint = await _dbContext.DataPoints.FirstOrDefaultAsync(dp => dp.Id == value);
        if (dataPoint == null)
        {
            dataPoint = new DataPoint() {Id = id, Value = value};
            _dbContext.DataPoints.Add(dataPoint);
        }
        else
        {
            dataPoint.Value = value;
        }

        try
        {
            await _dbContext.SaveChangesAsync();
            return Ok(dataPoint);
        }
        catch (Exception e)
        {
            return new StatusCodeResult(500);
        }
    }
}