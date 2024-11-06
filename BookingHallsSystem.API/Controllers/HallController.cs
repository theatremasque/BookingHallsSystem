using Microsoft.AspNetCore.Mvc;

namespace BookingHallsSystem.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class HallController : ControllerBase
{
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Hall test work..");
    }
}