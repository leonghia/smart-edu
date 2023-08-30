using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.ParentDTO;
using SmartEdu.DTOs.StudentDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : BaseController<Student>
    {
        public StudentController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams requestParams)
        {
            return await base.GetAll<GetStudentDTO>(requestParams, null, null,new List<string> { "User","Parent", "MainClass", });
        }

        [HttpGet("{id:int}", Name = "GetStudentById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await base.GetSingle<GetStudentDTO>(s => s.Id == id,
                new List<string> { "User", "Parent", "MainClass", });
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddStudentDTO addStudentDTO)
        {
            return await base.Add<AddStudentDTO>(addStudentDTO, "GetStudentById");
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentDTO updateStudentDTO)
        {
            return await base.Update<UpdateStudentDTO>(s => s.Id == id, updateStudentDTO);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(s => s.Id == id, id);
        }

    }
}
