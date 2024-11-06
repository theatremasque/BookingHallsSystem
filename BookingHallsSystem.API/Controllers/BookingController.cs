using Microsoft.AspNetCore.Mvc;

namespace BookingHallsSystem.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class BookingController : ControllerBase
{
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Booking test work..");
    }
}