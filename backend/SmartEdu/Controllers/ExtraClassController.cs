using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.ExtraClassDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.UnitOfWork;
using System.Buffers.Text;

namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ExtraClassController : BaseController<ExtraClass>
    {
        public ExtraClassController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Truy xuất toàn bộ lớp học thêm.
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams requestParams)
        {
            return await base.GetAll<GetExtraClassDTO>(requestParams, null, null, new List<string> { "Teacher.User", "Subject", "Students" });
        }

        /// <summary>
        /// Truy xuất 1 lớp học thêm hiện có theo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetExtraClassById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await base.GetSingle<GetExtraClassDTO>(ec => ec.Id == id, new List<string> { "Teacher.User", "Subject", "Students" });
        }

        /// <summary>
        /// Thêm mới 1 lớp học thêm.
        /// </summary>
        /// <param name="addExtraClassDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddExtraClassDTO addExtraClassDTO)
        {
            return await base.Add<AddExtraClassDTO>(addExtraClassDTO, "GetExtraClassById");
        }

        /// <summary>
        /// Cập nhật 1 lớp học thêm hiện có theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateExtraClassDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateExtraClassDTO updateExtraClassDTO)
        {
            return await base.Update<UpdateExtraClassDTO>(ec => ec.Id == id, updateExtraClassDTO);
        }

        /// <summary>
        /// Xóa 1 lớp học thêm hiện có theo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(ec => ec.Id == id, id);
        }
    }
}
