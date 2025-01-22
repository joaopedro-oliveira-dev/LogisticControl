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
[Authorize(Roles = "Administrador")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IValidator<UserPostDTO> _validatorPost;
    private readonly IValidator<UserPutDTO> _validatorPut;

    public UserController(IUserService userService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IValidator<UserPostDTO> validatorPost, IValidator<UserPutDTO> validatorPut)
    {
        _userService = userService;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _validatorPost = validatorPost;
        _validatorPut = validatorPut;
    }

    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserPostDTO modelDTO)
    {
        try
        {
            var validationDTO = await _validatorPost.ValidateAsync(modelDTO);

            if (validationDTO.IsValid)
            {
                var anotherUser = await _userService.GetUserAsyncByEmail(modelDTO.Email);
                if (anotherUser is null)
                {
                    User model = _mapper.Map<User>(modelDTO);
                    _userService.Add(model);
                }
                else return BadRequest("Já existe um usuário cadastrado com esse e-mail.");
            }
            else return BadRequest(validationDTO.Errors.Select(e => e.ErrorMessage));

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
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] UserPutDTO modelDTO)
    {
        try
        {
            var validationDTO = await _validatorPut.ValidateAsync(modelDTO);

            if (validationDTO.IsValid)
            {
                var anotherUser = await _userService.GetUserAsyncByEmail(modelDTO.Email);
                if (anotherUser is null)
                {
                    var user = await _userService.GetUserAsyncById(id);
                    if (user == null) return NotFound();
                    _mapper.Map(modelDTO, user);
                    _userService.Update(user);
                }
                else return BadRequest("Já existe um usuário cadastrado com esse e-mail.");
            }

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
    [HttpPut("active/{id}/{active}")]
    public async Task<IActionResult> PutActive(string id, bool active)
    {
        try
        {
            var user = await _userService.GetUserAsyncById(id);
            if (user == null) return NotFound();

            var httpContextUser = _httpContextAccessor?.HttpContext?.User;

            var userLogin = httpContextUser?.Identity?.Name;

            if (userLogin == null) return StatusCode(500);

            if (userLogin == user.Name) return BadRequest("Não é possível ativar/inativar o próprio usuário.");

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
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var user = await _userService.GetUserAsyncById(id);
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