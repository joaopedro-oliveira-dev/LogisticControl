using LogisticControl.Domain.Models;
using LogisticControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly IRepository _repo;

    public CompanyController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _repo.GetAllCompaniesAsync(true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetByCompanyId(int companyId)
    {
        try
        {
            var result = await _repo.GetCompanyAsyncById(companyId, true);
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
            var result = await _repo.GetCompanyAsyncByAddressId(addressId, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Company model)
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
    [HttpPut("{companyId}")]
    public async Task<IActionResult> Put(int companyId, [FromBody] Company model)
    {
        try
        {
            if (companyId != model.Id) return BadRequest();

            var company = await _repo.GetCompanyAsyncById(companyId);
            if (company == null) return NotFound();

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
    [HttpDelete("{companyId}")]
    public async Task<IActionResult> Delete(int companyId)
    {
        try
        {
            var address = await _repo.GetCompanyAsyncById(companyId);
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