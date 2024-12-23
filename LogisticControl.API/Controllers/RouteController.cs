using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Route = LogisticControl.Domain.Models.Route;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteController : ControllerBase
{
    private readonly IRouteService _routeService;

    public RouteController(IRouteService routeService)
    {
        _routeService = routeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _routeService.GetAllRoutesAsync(true, true);
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
            var result = await _routeService.GetRouteAsyncById(routeId, true, true);
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
            var result = await _routeService.GetRoutesAsyncByDriverId(driverId, true, true);
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
            var result = await _routeService.GetRouteAsyncByServiceId(serviceId, true, true);
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
            _routeService.Add(model);

            if (await _routeService.SaveChangesAsync())
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

            var route = await _routeService.GetRouteAsyncById(routeId);
            if (route == null) return NotFound();

            _routeService.Update(model);

            if (await _routeService.SaveChangesAsync())
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
            var route = await _routeService.GetRouteAsyncById(routeId);
            if (route == null) return NotFound();

            _routeService.Delete(route);

            if (await _routeService.SaveChangesAsync())
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