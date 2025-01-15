using AutoMapper;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Models;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Administrador")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserController(IUserService userService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
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
    [HttpPut("active/{userName}/{active}")]
    public async Task<IActionResult> PutActive(string userName, bool active)
    {
        try
        {
            var user = await _userService.GetUserAsyncByName(userName);
            if (user == null) return NotFound();

            var httpContextUser = _httpContextAccessor?.HttpContext?.User;

            var userLogin = httpContextUser?.Identity?.Name;

            if (userLogin == null) return StatusCode(500);

            if (userLogin == user.UserName) return BadRequest();

            user.Active = active;
            _userService.Update(user);

            if (await _userService.SaveChangesAsync())
            {
                if (user.Active) return Ok("Usuário ativado com sucesso.");
                else return Ok("Usuário inativado com sucesso.");
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

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var users = await _userService.GetAllUsers();


            return Ok(users);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

}