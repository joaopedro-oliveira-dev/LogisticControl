using AutoMapper;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Models;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;

    public CompanyController(ICompanyService companyService, IMapper mapper)
    {
        _companyService = companyService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _companyService.GetAllCompaniesAsync(true);
            
            var resultDTO = new List<CompanyGetDTO>();
            foreach (var company in result)
            {
                resultDTO.Add(_mapper.Map<CompanyGetDTO>(company));
            }

            return Ok(resultDTO);
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
            var result = await _companyService.GetCompanyAsyncById(companyId, true);
            
            var resultDTO = _mapper.Map<CompanyGetDTO>(result);

            return Ok(resultDTO);
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
            var result = await _companyService.GetCompanyAsyncByAddressId(addressId, true);

            var resultDTO = _mapper.Map<CompanyGetDTO>(result);

            return Ok(resultDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CompanyPostDTO modelDTO)
    {
        try
        {
            Company model = _mapper.Map<Company>(modelDTO);
            _companyService.Add(model);

            var resultDTO = _mapper.Map<CompanyGetDTO>(model);

            if (await _companyService.SaveChangesAsync())
            {
                return Ok(resultDTO);
            }

            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPut("{companyId}")]
    public async Task<IActionResult> Put(int companyId, [FromBody] CompanyPutDTO modelDTO)
    {
        try
        {
            Company company = await _companyService.GetCompanyAsyncById(companyId);
            if (company == null) return NotFound();

            _mapper.Map(modelDTO, company);
            _companyService.Update(company);

            var resultDTO = _mapper.Map<CompanyGetDTO>(company);

            if (await _companyService.SaveChangesAsync())
            {
                return Ok(resultDTO);
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
            var address = await _companyService.GetCompanyAsyncById(companyId);
            if (address == null) return NotFound();

            _companyService.Delete(address);

            if (await _companyService.SaveChangesAsync())
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