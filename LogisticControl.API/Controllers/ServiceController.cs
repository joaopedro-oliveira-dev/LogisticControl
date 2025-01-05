using AutoMapper;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Models;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Administrador, Analista")]
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
            var services = await _serviceService.GetAllServicesAsync(true, true);

            var servicesDTO = services.Select(s => _mapper.Map<ServiceGetDTO>(s)).ToList();
            return Ok(servicesDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{serviceId}")]
    public async Task<IActionResult> GetByServiceId(int serviceId)
    {
        try
        {
            var service = await _serviceService.GetServiceAsyncById(serviceId, true, true);
            if (service == null) return NotFound();

            var serviceDTO = _mapper.Map<ServiceGetDTO>(service);
            return Ok(serviceDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("address/{addressId}")]
    public async Task<IActionResult> GetByAddressId(int addressId)
    {
        try
        {
            var services = await _serviceService.GetServicesAsyncByAddressId(addressId, true, true);

            var servicesDTO = services.Select(s => _mapper.Map<ServiceGetDTO>(s)).ToList();
            return Ok(servicesDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpGet("route/{routeId}")]
    public async Task<IActionResult> GetByRouteId(int routeId)
    {
        try
        {
            var services = await _serviceService.GetServicesAsyncByRouteId(routeId, true, true);
            var servicesDTO = services.Select(s => _mapper.Map<ServiceGetDTO>(s)).ToList();
            return Ok(servicesDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
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
                return Ok("Serviço adicionado com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPut("{serviceId}")]
    public async Task<IActionResult> Put(int serviceId, [FromBody] ServicePutDTO modelDTO)
    {
        try
        {
            var service = await _serviceService.GetServiceAsyncById(serviceId);
            if (service == null) return NotFound();

            _mapper.Map(modelDTO, service);
            _serviceService.Update(service);

            if (await _serviceService.SaveChangesAsync())
            {
                return Ok("Serviço editado com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
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
                return Ok("Serviço deletado com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}