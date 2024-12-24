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
            var addresses = await _addressService.GetAllAddressesAsync(true);

            var addressesDTO = addresses.Select(a => _mapper.Map<AddressGetDTO>(a)).ToList();
            return Ok(addressesDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{addressId}")]
    public async Task<IActionResult> GetByAddressId(int addressId)
    {
        try
        {
            var address = await _addressService.GetAddressAsyncById(addressId, true);
            if (address == null) return NotFound();

            var addressDTO = _mapper.Map<AddressGetDTO>(address);
            return Ok(addressDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("company/{companyId}")]
    public async Task<IActionResult> GetByCompanyId(int companyId)
    {
        try
        {
            var addresses = await _addressService.GetAddressesAsyncByCompanyId(companyId, true);

            var addressesDTO = addresses.Select(a => _mapper.Map<AddressGetDTO>(a)).ToList();
            return Ok(addressesDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddressPostDTO modelDTO)
    {
        try
        {
            Address model = _mapper.Map<Address>(modelDTO);
            _addressService.Add(model);

            var addressDTO = _mapper.Map<AddressGetDTO>(model);

            if(await _addressService.SaveChangesAsync())
            {
                return Ok(addressDTO);
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPut("{addressId}")]
    public async Task<IActionResult> Put(int addressId, [FromBody] AddressPutDTO modelDTO)
    {
        try
        {
            var address = await _addressService.GetAddressAsyncById(addressId);
            if (address == null) return NotFound();

            _mapper.Map(modelDTO, address);
            _addressService.Update(address);

            var addressDTO = _mapper.Map<AddressGetDTO>(address);

            if (await _addressService.SaveChangesAsync()) 
            {
                return Ok(addressDTO);
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
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
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}