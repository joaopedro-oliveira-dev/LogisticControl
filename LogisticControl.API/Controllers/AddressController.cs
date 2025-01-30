using AutoMapper;
using FluentValidation;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Enums;
using LogisticControl.Domain.Models;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Administrador,Analista")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;
    private readonly IMapper _mapper;
    private readonly IValidator<AddressPostDTO> _validatorPost;
    private readonly IValidator<AddressPutDTO> _validatorPut;

    public AddressController(IAddressService addressService, IMapper mapper, IValidator<AddressPostDTO> validatorPost, IValidator<AddressPutDTO> validatorPut)
    {
        _addressService = addressService;
        _mapper = mapper;
        _validatorPost = validatorPost;
        _validatorPut = validatorPut;
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
            var validationDTO = await _validatorPost.ValidateAsync(modelDTO);

            if (validationDTO.IsValid)
            {
                Address model = _mapper.Map<Address>(modelDTO);
                _addressService.Add(model);
            }
            else return BadRequest(validationDTO.Errors.Select(e => e.ErrorMessage));

            if(await _addressService.SaveChangesAsync())
            {
                return Ok("Endereço adicionado com sucesso.");
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
            var validationDTO = await _validatorPut.ValidateAsync(modelDTO);

            if(validationDTO.IsValid)
            {
                var address = await _addressService.GetAddressAsyncById(addressId);
                if (address == null) return NotFound();

                _mapper.Map(modelDTO, address);
                _addressService.Update(address);
            }
            else
            {
                return BadRequest(validationDTO.Errors.Select(e => e.ErrorMessage));
            }

            if (await _addressService.SaveChangesAsync()) 
            {
                return Ok("Endereço editado com sucesso.");
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
                return Ok("Endereço deletado com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}