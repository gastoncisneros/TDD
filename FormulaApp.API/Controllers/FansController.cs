using Microsoft.AspNetCore.Mvc;

namespace FormulaApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FansController : Controller
    {
        [HttpGet("GetFans")]
        public async Task<IActionResult> Get()
        {
            return Ok("fans");
        }
    }
}
