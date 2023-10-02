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
    public class AcademicTrackerController : BaseController<AcademicTracker>
    {
        private readonly IClassService _classService;

        public AcademicTrackerController(IUnitOfWork unitOfWork, IMapper mapper, IClassService classService) : base(unitOfWork, mapper)
        {
            _classService = classService;
        }

        /// <summary>
        /// Retrieve academic trackers of a student from a specific range of dates by his Id.
        /// </summary>
        /// <param name="academicTrackerRequestParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetByStudentId([FromQuery] AcademicTrackerRequestParams academicTrackerRequestParams)
        {
            var response = await _classService.GetAcademicTrackersByStudent(academicTrackerRequestParams);

            return Ok(response);
        }
    }
}