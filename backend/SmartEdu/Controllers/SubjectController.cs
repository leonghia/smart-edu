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

        /// <summary>
        /// Truy xuất toàn bộ môn học 
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams requestParams)
        {
            return await base.GetAll<GetSubjectDTO>(requestParams, null, null,null);
        }


        /// <summary>
        /// Truy xuất một môn học hiện có theo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetSubjectById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await base.GetSingle<GetSubjectDTO>(sub => sub.Id == id, null);
        }


        /// <summary>
        /// Thêm mới một môn học.
        /// </summary>
        /// <param name="addSubjectDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddSubjectDTO addSubjectDTO)
        {
            return await base.Add(addSubjectDTO, "GetSubjectById");
        }


        /// <summary>
        /// Cập nhật môn học hiện có theo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateSubjectDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSubjectDTO updateSubjectDTO)
        {
            return await base.Update<UpdateSubjectDTO>(sub => sub.Id == id, updateSubjectDTO);
        }

        /// <summary>
        /// Xóa một môn học hiện có theo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(sub => sub.Id == id, id);
        }


    }
}
