using LogisticControl.Domain.Models;
using LogisticControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : ControllerBase
{
    private readonly IRepository _repo;

    public DriverController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _repo.GetAllDriversAsync(true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("{driverId}")]
    public async Task<IActionResult> GetByDriverId(int driverId)
    {
        try
        {
            var result = await _repo.GetDriverAsyncById(driverId, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("route/{routeId}")]
    public async Task<IActionResult> GetByCompanyId(int routeId)
    {
        try
        {
            var result = await _repo.GetDriverAsyncByRouteId(routeId, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Driver model)
    {
        try
        {
            _repo.Add(model);

            if (await _repo.SaveChangesAsync())
            {
                return Ok(model);
            }

            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPut("{driverId}")]
    public async Task<IActionResult> Put(int driverId, [FromBody] Driver model)
    {
        try
        {
            if (driverId != model.Id) return BadRequest();

            var address = await _repo.GetDriverAsyncById(driverId);
            if (address == null) return NotFound();

            _repo.Update(model);

            if (await _repo.SaveChangesAsync())
            {
                return Ok(model);
            }

            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpDelete("{driverId}")]
    public async Task<IActionResult> Delete(int driverId)
    {
        try
        {
            var address = await _repo.GetDriverAsyncById(driverId);
            if (address == null) return NotFound();

            _repo.Delete(address);

            if (await _repo.SaveChangesAsync())
            {
                return Ok("Deletado");
            }

            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
}