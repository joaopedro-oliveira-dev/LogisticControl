using AutoMapper;
using FluentValidation;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Models;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IValidator<LoginDTO> _validator;

    public AuthenticationController(ITokenService tokenService, IMapper mapper, IValidator<LoginDTO> validator)
    {
        _tokenService = tokenService;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        try
        {
            var validationDTO = await _validator.ValidateAsync(loginDTO);

            if (validationDTO.IsValid)
            {
                var userLogin = _mapper.Map<User>(loginDTO);
                var token = await _tokenService.GenerateToken(userLogin);
                if (token == "") return Unauthorized("E-mail ou senha incorretos.");
                return Ok(token);
            }
            else return BadRequest(validationDTO.Errors.Select(e => e.ErrorMessage));
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}