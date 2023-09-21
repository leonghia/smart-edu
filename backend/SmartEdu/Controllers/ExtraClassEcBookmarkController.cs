using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.EcBookmarkDTO;
using SmartEdu.Entities;
using SmartEdu.Services.ClassService;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExtraClassEcBookmarkController : BaseController<ExtraClassEcBookmark>
{
    private readonly IClassService _classService;

    public ExtraClassEcBookmarkController(IUnitOfWork unitOfWork, IMapper mapper, IClassService classService) : base(unitOfWork, mapper)
    {
        this._classService = classService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddExtraClassEcBookmarkDTO addExtraClassEcBookmarkDTO)
    {
        return await base.Add<AddExtraClassEcBookmarkDTO>(addExtraClassEcBookmarkDTO, "");
    }

    [HttpPut]
    public async Task<IActionResult> Delete([FromBody] DeleteExtraClassEcBookmarkDTO deleteExtraClassEcBookmarkDTO)
    {
        var serverResponse = await _classService.UnBookmark(deleteExtraClassEcBookmarkDTO);
        if (!serverResponse.Succeeded)
        {
            return BadRequest(serverResponse);
        }
        return Ok(serverResponse);
    }
}