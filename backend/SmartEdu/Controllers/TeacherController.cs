using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.DocumentDTO;
using SmartEdu.DTOs.TeacherDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.UnitOfWork;

namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : BaseController<Teacher>
    {
        public TeacherController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Truy xuất toàn bộ giáo viên.
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams requestParams)
        {
            return await base.GetAll<GetTeacherDTO>(requestParams,null ,null, new List<string> { "User", "MainClass", "Subject" });
        }


        /// <summary>
        /// Truy xuất 1 giáo viên hiện có theo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetTeacherById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await base.GetSingle<GetTeacherDTO>(t => t.Id == id,
                new List<string> { "User", "MainClass", "Subject" });
        }


        /// <summary>
        /// Thêm mới một giáo viên.
        /// </summary>
        /// <param name="addTeacherDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTeacherDTO addTeacherDTO)
        {
            return await base.Add<AddTeacherDTO>(addTeacherDTO, "GetTeacherById");
        }

        /// <summary>
        /// Cập nhật một giáo viên hiện có theo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateTeacherDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTeacherDTO updateTeacherDTO)
        {
            return await base.Update<UpdateTeacherDTO>(t => t.Id == id, updateTeacherDTO);
        }

        /// <summary>
        /// Xóa một giáo viên hiện có theo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(t => t.Id == id, id);
        }
    }
}