using AutoMapper;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Models;
using LogisticControl.Services;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Administrador")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserPostDTO modelDTO)
    {
        try
        {
            User model = _mapper.Map<User>(modelDTO);
            _userService.Add(model);

            if (await _userService.SaveChangesAsync())
            {
                return Ok("Usuário criado com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPut("{userName}")]
    public async Task<IActionResult> Put(string userName, [FromBody] UserPutDTO modelDTO)
    {
        try
        {
            var user = await _userService.GetUserAsyncByName(userName);
            if (user == null) return NotFound();

            _mapper.Map(modelDTO, user);
            _userService.Update(user);

            if (await _userService.SaveChangesAsync())
            {
                return Ok("Usuário editado com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpDelete("{userName}")]
    public async Task<IActionResult> Delete(string userName)
    {
        try
        {
            var user = await _userService.GetUserAsyncByName(userName);
            if (user == null) return NotFound();

            _userService.Delete(user);

            if (await _userService.SaveChangesAsync())
            {
                return Ok("Usuário deletado com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}