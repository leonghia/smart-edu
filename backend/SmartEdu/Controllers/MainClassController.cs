using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.MainClassDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.Services.ClassService;
using SmartEdu.UnitOfWork;
using System.Buffers.Text;

namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainClassController : BaseController<MainClass>
    {
        

        public MainClassController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            
        }

        /// <summary>
        /// Truy xuất toàn bộ lớp học chính.
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams queryParams)
        {
            return await base.GetAll<GetMainClassDTO>(queryParams, null, null, new List<string> {"Teacher.User"});
        }

        /// <summary>
        /// Truy xuất 1 lớp học chính theo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetMainClassById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await base.GetSingle<GetMainClassDTO>(m => m.Id == id, new List<string> {"Teacher.User", "Students.Marks"});
        }

        /// <summary>
        /// Thêm mới 1 lớp học thêm.
        /// </summary>
        /// <param name="addMainClassDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMainClassDTO addMainClassDTO)
        {
            return await base.Add<AddMainClassDTO>(addMainClassDTO, "GetMainClassById");
        }

        /// <summary>
        /// Cập nhật 1 lớp học chính hiện có theo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateMainClassDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMainClassDTO updateMainClassDTO)
        {
            return await base.Update<UpdateMainClassDTO>(m => m.Id == id, updateMainClassDTO);
        }

        /// <summary>
        /// Xóa 1 lớp học chính theo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(m => m.Id == id, id);
        }
    }
}
