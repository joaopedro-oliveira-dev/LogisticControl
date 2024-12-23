using AutoMapper;
using LogisticControl.Domain.DTOs;
using LogisticControl.Domain.Models;
using LogisticControl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
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
            var result = await _driverService.GetAllDriversAsync(true);

            var resultDTO = new List<DriverGetDTO>();

            foreach(var driver in result)
            {
                resultDTO.Add(_mapper.Map<DriverGetDTO>(driver));
            }

            return Ok(resultDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("{driverId}")]
    public async Task<IActionResult> GetByDriverId(int driverId)
    {
        try
        {
            var result = await _driverService.GetDriverAsyncById(driverId, true);

            var resultDTO = _mapper.Map<DriverGetDTO>(result);

            return Ok(resultDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("route/{routeId}")]
    public async Task<IActionResult> GetByCompanyId(int routeId)
    {
        try
        {
            var result = await _driverService.GetDriverAsyncByRouteId(routeId, true);

            var resultDTO = _mapper.Map<DriverGetDTO>(result);

            return Ok(resultDTO);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DriverPostDTO modelDTO)
    {
        try
        {
            Driver model = _mapper.Map<Driver>(modelDTO);
            _driverService.Add(model);

            var resultDTO = _mapper.Map<DriverGetDTO>(model);

            if (await _driverService.SaveChangesAsync())
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
    [HttpPut("{driverId}")]
    public async Task<IActionResult> Put(int driverId, [FromBody] DriverPutDTO modelDTO)
    {
        try
        {
            Driver driver = await _driverService.GetDriverAsyncById(driverId);
            if (driver == null) return NotFound();

            _mapper.Map(modelDTO, driver);
            _driverService.Update(driver);

            var resultDTO = _mapper.Map<DriverGetDTO>(driver);

            if (await _driverService.SaveChangesAsync())
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
    [HttpDelete("{driverId}")]
    public async Task<IActionResult> Delete(int driverId)
    {
        try
        {
            var address = await _driverService.GetDriverAsyncById(driverId);
            if (address == null) return NotFound();

            _driverService.Delete(address);

            if (await _driverService.SaveChangesAsync())
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