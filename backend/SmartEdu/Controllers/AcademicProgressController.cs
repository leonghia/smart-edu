using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.Services.ClassService;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AcademicProgressController : BaseController<AcademicProgress>
{
    private readonly IClassService _classService;

    public AcademicProgressController(IUnitOfWork unitOfWork, IMapper mapper, IClassService classService) : base(unitOfWork, mapper)
    {
        _classService = classService;
    }

    /// <summary>
    /// Retrieve academic progresses by optional params.
    /// </summary>
    /// <param name="academicProgressRequestParams"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetByDate([FromQuery] AcademicProgressRequestParams academicProgressRequestParams)
    {
        var response = await _classService.GetAcademicProgressesByDate(academicProgressRequestParams);
        return Ok(response);
    } 
}