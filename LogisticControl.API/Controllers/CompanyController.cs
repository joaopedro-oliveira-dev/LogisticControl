using AutoMapper;
using FluentValidation;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Models;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize(Roles = "Administrador,Analista")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;

    public CompanyController(ICompanyService companyService, IMapper mapper, IValidator<CompanyPostDTO> validatorPost, IValidator<CompanyPutDTO> validatorPut)
    {
        _companyService = companyService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var companies = await _companyService.GetAllCompaniesAsync(true);

            var companiesDTO = companies.Select(c => _mapper.Map<CompanyGetDTO>(c)).ToList();
            return Ok(companiesDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetByCompanyId(int companyId)
    {
        try
        {
            var company = await _companyService.GetCompanyAsyncById(companyId, true);
            if (company == null) return NotFound();
            
            var companyDTO = _mapper.Map<CompanyGetDTO>(company);
            return Ok(companyDTO);
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
            var company = await _companyService.GetCompanyAsyncByAddressId(addressId, true);
            if (company == null) return NotFound();

            var companyDTO = _mapper.Map<CompanyGetDTO>(company);
            return Ok(companyDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CompanyPostDTO modelDTO)
    {
        try
        {
            if (ModelState.IsValid)
            {
                Company model = _mapper.Map<Company>(modelDTO);
                _companyService.Add(model);
            }
            else return BadRequest(ModelState);

            if (await _companyService.SaveChangesAsync())
            {
                return Ok("Empresa criada com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPut("{companyId}")]
    public async Task<IActionResult> Put(int companyId, [FromBody] CompanyPutDTO modelDTO)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var company = await _companyService.GetCompanyAsyncById(companyId);
                if (company == null) return NotFound();
                _mapper.Map(modelDTO, company);
                _companyService.Update(company);
            }
            else return BadRequest(ModelState);           

            if (await _companyService.SaveChangesAsync())
            {
                return Ok("Empresa editada com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpDelete("{companyId}")]
    public async Task<IActionResult> Delete(int companyId)
    {
        try
        {
            var company = await _companyService.GetCompanyAsyncById(companyId);
            if (company == null) return NotFound();

            _companyService.Delete(company);

            if (await _companyService.SaveChangesAsync())
            {
                return Ok("Empresa deletada com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}