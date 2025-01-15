using AutoMapper;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Models;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Administrador")]
public class DriverController : ControllerBase
{
    private readonly IDriverService _driverService;
    private readonly IMapper _mapper;

    public DriverController(IDriverService driverService, IMapper mapper)
    {
        _driverService = driverService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var companies = await _driverService.GetAllDriversAsync(true);

            var companiesDTO = companies.Select(c => _mapper.Map<DriverGetDTO>(c)).ToList();
            return Ok(companiesDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{driverId}")]
    public async Task<IActionResult> GetByDriverId(int driverId)
    {
        try
        {
            var driver = await _driverService.GetDriverAsyncById(driverId, true);
            if (driver == null) return NotFound();

            var driverDTO = _mapper.Map<DriverGetDTO>(driver);
            return Ok(driverDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("route/{routeId}")]
    public async Task<IActionResult> GetByRouteId(int routeId)
    {
        try
        {
            var driver = await _driverService.GetDriverAsyncByRouteId(routeId, true);
            if (driver == null) return NotFound();

            var driverDTO = _mapper.Map<DriverGetDTO>(driver);
            return Ok(driverDTO);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DriverPostDTO modelDTO)
    {
        try
        {
            Driver model = _mapper.Map<Driver>(modelDTO);
            _driverService.Add(model);

            if (await _driverService.SaveChangesAsync())
            {
                return Ok("Motorista adicionado com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPut("{driverId}")]
    public async Task<IActionResult> Put(int driverId, [FromBody] DriverPutDTO modelDTO)
    {
        try
        {
            var driver = await _driverService.GetDriverAsyncById(driverId);
            if (driver == null) return NotFound();

            _mapper.Map(modelDTO, driver);
            _driverService.Update(driver);

            if (await _driverService.SaveChangesAsync())
            {
                return Ok("Motorista editado com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpDelete("{driverId}")]
    public async Task<IActionResult> Delete(int driverId)
    {
        try
        {
            var driver = await _driverService.GetDriverAsyncById(driverId);
            if (driver == null) return NotFound();

            _driverService.Delete(driver);

            if (await _driverService.SaveChangesAsync())
            {
                return Ok("Motorista deletado com sucesso.");
            }

            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}