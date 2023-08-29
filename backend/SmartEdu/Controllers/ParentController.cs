using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.ParentDTO;
using SmartEdu.DTOs.TeacherDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : BaseController<Parent>
    {
        public ParentController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams requestParams)
        {
            return await base.GetAll<GetParentDTO>(requestParams,null,null,new List<string> { "User" });
        }

        [HttpGet("{id:int}", Name = "GetParentById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await base.GetSingle<GetParentDTO>(p => p.Id == id,
                new List<string> { "User" });
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddParentDTO addParentDTO)
        {
            return await base.Add<AddParentDTO>(addParentDTO, "GetParentById");
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateParentDTO updateParentDTO)
        {
            return await base.Update<UpdateParentDTO>(p => p.Id == id, updateParentDTO);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(p => p.Id == id, id);
        }

    }
}
