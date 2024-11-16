using Microsoft.AspNetCore.Mvc;

namespace LogisticControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
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