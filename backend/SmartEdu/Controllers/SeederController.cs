using Microsoft.AspNetCore.Mvc;
using SmartEdu.Services.SeederService;

namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeederController : ControllerBase
    {
        private readonly ISeederService _seederService;
        public SeederController(ISeederService seederService) 
        { 
            _seederService = seederService;
        }

        /// <summary>
        /// Seeding dữ liệu đầu vào (sau khi chạy lệnh database-update).
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            var response = await _seederService.SeedingData();
            return StatusCode(201, response);
        }
    }
}
