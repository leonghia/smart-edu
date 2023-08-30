using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.ExamDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.UnitOfWork;


namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : BaseController<Exam>
    {
        public ExamController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        /// <summary>
        /// Truy xuất toàn bộ bài kiểm tra.
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams requestParams)
        {
            return await base.GetAll<GetExamDTO>(requestParams, null, null, new List<string> { "Student", "Subject" });
        }

        /// <summary>
        /// Truy xuất bài kiểm tra theo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetExamById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await base.GetSingle<GetExamDTO>(e => e.Id == id, new List<string> { "Student", "Subject" });
        }

        /// <summary>
        /// Thêm mới 1 bài kiểm tra.
        /// </summary>
        /// <param name="addExamDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddExamDTO addExamDTO)
        {
            return await base.Add<AddExamDTO>(addExamDTO, "GetExamById");
        }

        /// <summary>
        /// Cập nhật 1 bài kiểm tra hiện có theo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateExamDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateExamDTO updateExamDTO)
        {
            return await base.Update<UpdateExamDTO>(e => e.Id == id, updateExamDTO);
        }

        /// <summary>
        /// Xóa 1 bài kiểm tra hiện có theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(e => e.Id == id, id);

        }
    }
}
