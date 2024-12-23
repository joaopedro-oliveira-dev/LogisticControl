using AutoMapper;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Models;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;
    private readonly IMapper _mapper;
    
    public AddressController(IAddressService addressService, IMapper mapper) 
    {
        _addressService = addressService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _addressService.GetAllAddressesAsync(true);
            var resultDTO = new List<AddressGetDTO>();
            foreach (var address in result)
            {
                resultDTO.Add(_mapper.Map<AddressGetDTO>(address));
            }
            return Ok(resultDTO);
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
            var result = await _addressService.GetAddressAsyncById(addressId, true);
            var resultDTO = _mapper.Map<AddressGetDTO>(result);
            return Ok(resultDTO);
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
            var result = await _addressService.GetAddressesAsyncByCompanyId(companyId, true);
            var resultDTO = new List<AddressGetDTO>();
            foreach (var address in result)
            {
                resultDTO.Add(_mapper.Map<AddressGetDTO>(address));
            }
            return Ok(resultDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddressPostDTO modelDTO)
    {
        try
        {
            Address model = _mapper.Map<Address>(modelDTO);
            _addressService.Add(model);

            var resultDTO = _mapper.Map<AddressGetDTO>(model);

            if(await _addressService.SaveChangesAsync())
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
    [HttpPut("{addressId}")]
    public async Task<IActionResult> Put(int addressId, [FromBody] AddressPutDTO modelDTO)
    {
        try
        {
            Address address = await _addressService.GetAddressAsyncById(addressId);
            if (address == null) return NotFound();

            _mapper.Map(modelDTO, address);

            _addressService.Update(address);

            var resultDTO = _mapper.Map<AddressGetDTO>(address);

            if (await _addressService.SaveChangesAsync()) 
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
    [HttpDelete("{addressId}")]
    public async Task<IActionResult> Delete(int addressId)
    {
        try
        {
            var address = await _addressService.GetAddressAsyncById(addressId);
            if (address == null) return NotFound();

            _addressService.Delete(address);

            if (await _addressService.SaveChangesAsync())
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