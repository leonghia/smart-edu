using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.Entities;
using SmartEdu.Services.ClassService;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcademicTrackerController : BaseController<AcademicTracker>
    {
        private readonly IClassService _classService;

        public AcademicTrackerController(IUnitOfWork unitOfWork, IMapper mapper, IClassService classService) : base(unitOfWork, mapper)
        {
            _classService = classService;
        }

        /// <summary>
        /// Retrieve academic trackers of a student by his Id.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetByStudentId([FromQuery] int studentId)
        {
            var response = await _classService.GetAcademicTrackersByStudent(studentId);

            return Ok(response);
        }
    }
}