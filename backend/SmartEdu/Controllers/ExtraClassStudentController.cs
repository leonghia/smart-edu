using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.ExtraClassStudentDTO;
using SmartEdu.Entities;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExtraClassStudentController : BaseController<ExtraClassStudent>
{
    public ExtraClassStudentController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddExtraClassStudentDTO addExtraClassStudentDTO) {
        return await base.Add<AddExtraClassStudentDTO>(addExtraClassStudentDTO, "");
    }
}
