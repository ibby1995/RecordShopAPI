using Microsoft.AspNetCore.Mvc;

namespace RecordShopAPI.Controllers
{
    [Route("/health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok("Healthy");
        }
    }
}