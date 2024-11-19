using LogisticControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    public AddressController(IRepository repo) 
    {

    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok("");
        }
        catch (Exception ex)
        {
            return BadRequest($"ERRO: {ex.Message}");
        }
    }
}