using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.Services.ClassService;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimetableController : BaseController<Timetable>
    {
        private readonly IClassService _classService;

        public TimetableController(IUnitOfWork unitOfWork, IMapper mapper, IClassService classService) : base(unitOfWork, mapper)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByWeek([FromQuery] TimetableRequestParams timetableRequestParams)
        {
            var response = await _classService.GetTimetableByWeek(timetableRequestParams);
            if (!response.Succeeded)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}