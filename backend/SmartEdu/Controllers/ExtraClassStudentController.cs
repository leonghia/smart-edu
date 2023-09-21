using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.ExtraClassStudentDTO;
using SmartEdu.Entities;
using SmartEdu.Services.ClassService;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExtraClassStudentController : BaseController<ExtraClassStudent>
{
    private readonly IClassService _classService;

    public ExtraClassStudentController(IUnitOfWork unitOfWork, IMapper mapper, IClassService classService) : base(unitOfWork, mapper)
    {
        this._classService = classService;
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddExtraClassStudentDTO addExtraClassStudentDTO) {
        return await base.Add<AddExtraClassStudentDTO>(addExtraClassStudentDTO, "");
    }

    [HttpPut]
    public async Task<IActionResult> Delete([FromBody] DeleteExtraClassStudentDTO deleteExtraClassStudentDTO)
    {
        var response = await _classService.UnRegister(deleteExtraClassStudentDTO);
        if (response.Succeeded)
        {
            return Ok(response); // Da xoa thanh cong
        }
        return StatusCode(400, response); //Xoa that bai
    }
}
