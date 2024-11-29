using LogisticControl.Domain;
using LogisticControl.Domain.Models;
using LogisticControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly IRepository _repo;
    
    public AddressController(IRepository repo) 
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _repo.GetAllAddressesAsync(true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("{addressId}")]
    public async Task<IActionResult> GetByAddressId(int addressId)
    {
        try
        {
            var result = await _repo.GetAddressAsyncById(addressId, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("company/{companyId}")]
    public async Task<IActionResult> GetByCompanyId(int companyId)
    {
        try
        {
            var result = await _repo.GetAddressesAsyncByCompanyId(companyId, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Address model)
    {
        try
        {
            _repo.Add(model);

            if(await _repo.SaveChangesAsync())
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
    [HttpPut("{addressId}")]
    public async Task<IActionResult> Put(int addressId, [FromBody] Address model)
    {
        try
        {
            if (addressId != model.Id) return BadRequest();
            
            var address = await _repo.GetAddressAsyncById(addressId);
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
    [HttpDelete("{addressId}")]
    public async Task<IActionResult> Delete(int addressId)
    {
        try
        {
            var address = await _repo.GetAddressAsyncById(addressId);
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