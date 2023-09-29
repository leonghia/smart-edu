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
    public class MarkController : BaseController<Mark>
    {
        private readonly IClassService _classService;

        public MarkController(IUnitOfWork unitOfWork, IMapper mapper, IClassService classService) : base(unitOfWork, mapper)
        {
            _classService = classService;
        }

        /// <summary>
        /// Tính xếp hạng của học sinh theo kỳ hoặc cả năm (semester = 3 là cả năm).
        /// </summary>
        /// <param name="id"></param>
        /// <param name="markFilterOption"></param>
        /// <returns></returns>
        [HttpGet("ranking/{id:int}")]
        public async Task<IActionResult> GetRanking([FromRoute] int id, [FromQuery] MarkFilterOption markFilterOption)
        {
            var response = await _classService.GetRanking(id, markFilterOption);
            return Ok(response);
        }
    }
}