using LogisticControl.Domain.Models;
using LogisticControl.Repository;
using Microsoft.AspNetCore.Mvc;
using Route = LogisticControl.Domain.Models.Route;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteController : ControllerBase
{
    private readonly IRepository _repo;

    public RouteController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _repo.GetAllRoutesAsync(true, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("{routeId}")]
    public async Task<IActionResult> GetByRouteId(int routeId)
    {
        try
        {
            var result = await _repo.GetRouteAsyncById(routeId, true, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("driver/{driverId}")]
    public async Task<IActionResult> GetByDriverId(int driverId)
    {
        try
        {
            var result = await _repo.GetRoutesAsyncByDriverId(driverId, true, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpGet("service/{serviceId}")]
    public async Task<IActionResult> GetByServiceId(int serviceId)
    {
        try
        {
            var result = await _repo.GetRouteAsyncByServiceId(serviceId, true, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Route model)
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
    [HttpPut("{routeId}")]
    public async Task<IActionResult> Put(int routeId, [FromBody] Route model)
    {
        try
        {
            if (routeId != model.Id) return BadRequest();

            var route = await _repo.GetRouteAsyncById(routeId);
            if (route == null) return NotFound();

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
    [HttpDelete("{routeId}")]
    public async Task<IActionResult> Delete(int routeId)
    {
        try
        {
            var route = await _repo.GetRouteAsyncById(routeId);
            if (route == null) return NotFound();

            _repo.Delete(route);

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