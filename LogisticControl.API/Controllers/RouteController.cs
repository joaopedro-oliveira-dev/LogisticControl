using AutoMapper;
using LogisticControl.Domain.DTOs;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Route = LogisticControl.Domain.Models.Route;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteController : ControllerBase
{
    private readonly IRouteService _routeService;
    private readonly IMapper _mapper;
    public RouteController(IRouteService routeService, IMapper mapper)
    {
        _routeService = routeService;
        _mapper = mapper;
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
    public async Task<IActionResult> Post([FromBody] RoutePostDTO modelDTO)
    {
        try
        {
            Route model = _mapper.Map<Route>(modelDTO);
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
    public async Task<IActionResult> Put(int routeId, [FromBody] RoutePutDTO modelDTO)
    {
        try
        {
            Route route = await _routeService.GetRouteAsyncById(routeId);
            if (route == null) return NotFound();

            _mapper.Map(modelDTO, route);
            _routeService.Update(route);

            if (await _routeService.SaveChangesAsync())
            {
                return Ok(route);
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