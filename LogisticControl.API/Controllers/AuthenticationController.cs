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

    public AuthenticationController(ITokenService tokenService, IMapper mapper, IValidator<LoginDTO> validator)
    {
        _tokenService = tokenService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var userLogin = _mapper.Map<User>(loginDTO);
                var token = await _tokenService.GenerateToken(userLogin);
                if (token == "") return Unauthorized("E-mail ou senha incorretos.");
                return Ok(token);
            }
            else return BadRequest(ModelState);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}