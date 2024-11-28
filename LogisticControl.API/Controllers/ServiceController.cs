using LogisticControl.Domain.Models;
using LogisticControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceController : ControllerBase
{
    private readonly IRepository _repo;

    public ServiceController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _repo.GetAllServicesAsync(true, true);
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
            var result = await _repo.GetServiceAsyncById(serviceId, true, true);
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
            var result = await _repo.GetServicesAsyncByAddressId(addressId, true, true);
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
            var result = await _repo.GetServicesAsyncByRouteId(routeId, true, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Service model)
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
    [HttpPut("{serviceId}")]
    public async Task<IActionResult> Put(int serviceId, [FromBody] Service model)
    {
        try
        {
            if (serviceId != model.Id) return BadRequest();

            var service = await _repo.GetServiceAsyncById(serviceId);
            if (service == null) return NotFound();

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
    [HttpDelete("{serviceId}")]
    public async Task<IActionResult> Delete(int serviceId)
    {
        try
        {
            var service = await _repo.GetServiceAsyncById(serviceId);
            if (service == null) return NotFound();

            _repo.Delete(service);

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