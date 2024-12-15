using AutoMapper;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Models;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IMapper _mapper;

    public ServiceController(IServiceService serviceService, IMapper mapper)
    {
        _serviceService = serviceService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _serviceService.GetAllServicesAsync(true, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("{serviceId}")]
    public async Task<IActionResult> GetByServiceId(int serviceId)
    {
        try
        {
            var result = await _serviceService.GetServiceAsyncById(serviceId, true, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("address/{addressId}")]
    public async Task<IActionResult> GetByAddressId(int addressId)
    {
        try
        {
            var result = await _serviceService.GetServicesAsyncByAddressId(addressId, true, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpGet("route/{routeId}")]
    public async Task<IActionResult> GetByRouteId(int routeId)
    {
        try
        {
            var result = await _serviceService.GetServicesAsyncByRouteId(routeId, true, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ServicePostDTO modelDTO)
    {
        try
        {
            Service model = _mapper.Map<Service>(modelDTO);
            _serviceService.Add(model);

            if (await _serviceService.SaveChangesAsync())
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
    [HttpPut("{serviceId}")]
    public async Task<IActionResult> Put(int serviceId, [FromBody] ServicePutDTO modelDTO)
    {
        try
        {
            Service service = await _serviceService.GetServiceAsyncById(serviceId);
            if (service == null) return NotFound();

            _mapper.Map(modelDTO, service);
            _serviceService.Update(service);

            if (await _serviceService.SaveChangesAsync())
            {
                return Ok(service);
            }

            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpDelete("{serviceId}")]
    public async Task<IActionResult> Delete(int serviceId)
    {
        try
        {
            var service = await _serviceService.GetServiceAsyncById(serviceId);
            if (service == null) return NotFound();

            _serviceService.Delete(service);

            if (await _serviceService.SaveChangesAsync())
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