using FormulaApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormulaApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FansController(IFanService fanService) : Controller
    {
        private readonly IFanService _fanService = fanService;

        [HttpGet("GetFans")]
        public async Task<IActionResult> Get()
        {
            var fans = await _fanService.GetAllFans();

            if(fans.Any()) return Ok(fans);

            return NotFound();
        }
    }
}
