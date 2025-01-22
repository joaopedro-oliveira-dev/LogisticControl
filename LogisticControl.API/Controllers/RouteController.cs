using AutoMapper;
using FluentValidation;
using LogisticControl.Domain.DTOs;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Route = LogisticControl.Domain.Models.Route;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Administrador,Analista")]
public class RouteController : ControllerBase
{
    private readonly IRouteService _routeService;
    private readonly IMapper _mapper;
    private readonly IValidator<RoutePostDTO> _validatorPost;
    private readonly IValidator<RoutePutDTO> _validatorPut;
    public RouteController(IRouteService routeService, IMapper mapper, IValidator<RoutePostDTO> validatorPost, IValidator<RoutePutDTO> validatorPut)
    {
        _routeService = routeService;
        _mapper = mapper;
        _validatorPost = validatorPost;
        _validatorPut = validatorPut;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var routes = await _routeService.GetAllRoutesAsync(true, true);
           
            var routesDTO = routes.Select(r => _mapper.Map<RouteGetDTO>(r)).ToList();
            return Ok(routesDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{routeId}")]
    public async Task<IActionResult> GetByRouteId(int routeId)
    {
        try
        {
            var route = await _routeService.GetRouteAsyncById(routeId, true, true);
            if (route == null) return NotFound();

            var routeDTO = _mapper.Map<RouteGetDTO>(route);
            return Ok(routeDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("driver/{driverId}")]
    public async Task<IActionResult> GetByDriverId(int driverId)
    {
        try
        {
            var routes = await _routeService.GetRoutesAsyncByDriverId(driverId, true, true);
            
            var routesDTO = routes.Select(r => _mapper.Map<RouteGetDTO>(r)).ToList();
            return Ok(routesDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpGet("service/{serviceId}")]
    public async Task<IActionResult> GetByServiceId(int serviceId)
    {
        try
        {
            var route = await _routeService.GetRouteAsyncByServiceId(serviceId, true, true);
            if (route == null) return NotFound();

            var routeDTO = _mapper.Map<RouteGetDTO>(route);
            return Ok(routeDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RoutePostDTO modelDTO)
    {
        try
        {
            var validationDTO = await _validatorPost.ValidateAsync(modelDTO);

            if (validationDTO.IsValid)
            {
                Route model = _mapper.Map<Route>(modelDTO);
                _routeService.Add(model);
            }
            else return BadRequest(validationDTO.Errors.Select(e => e.ErrorMessage));

            if (await _routeService.SaveChangesAsync())
            {
                return Ok("Rota adicionada com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPut("{routeId}")]
    public async Task<IActionResult> Put(int routeId, [FromBody] RoutePutDTO modelDTO)
    {
        try
        {
            var validationDTO = await _validatorPut.ValidateAsync(modelDTO);

            if (validationDTO.IsValid)
            {
                var route = await _routeService.GetRouteAsyncById(routeId);
                if (route == null) return NotFound();
                _mapper.Map(modelDTO, route);
                _routeService.Update(route);
            }
            else return BadRequest(validationDTO.Errors.Select(e => e.ErrorMessage));

            if (await _routeService.SaveChangesAsync())
            {
                return Ok("Rota editada com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpDelete("{routeId}")]
    public async Task<IActionResult> Delete(int routeId)
    {
        try
        {
            var route = await _routeService.GetRouteAsyncById(routeId);
            if (route == null) return NotFound();

            _routeService.Delete(route);

            if (await _routeService.SaveChangesAsync())
            {
                return Ok("Rota deletada com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}