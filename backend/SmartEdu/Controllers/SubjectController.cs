using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.SubjectDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : BaseController<Subject>
    {
        public SubjectController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams requestParams)
        {
            return await base.GetAll<GetSubjectDTO>(requestParams,null,null,new List<string>{"Name"});
        }

        [HttpGet("{id:int}", Name = "GetSubjectById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await base.GetSingle<GetSubjectDTO>(sub => sub.Id == id,
                new List<string> { "Subject" });
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddSubjectDTO addSubjectDTO)
        {
            return await base.Add<AddSubjectDTO>(addSubjectDTO, "GetParentById");
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSubjectDTO updateSubjectDTO)
        {
            return await base.Update<UpdateSubjectDTO>(sub => sub.Id == id, updateSubjectDTO);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(sub => sub.Id == id, id);
        }

    }
}
