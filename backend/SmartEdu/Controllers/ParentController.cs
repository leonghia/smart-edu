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

        /// <summary>
        /// Truy xuất toàn bộ phụ huynh.
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams requestParams)
        {
            return await base.GetAll<GetParentDTO>(requestParams,null,null,new List<string> { "User" });
        }

        /// <summary>
        /// Truy xuất một phụ huynh hiện có theo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetParentById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await base.GetSingle<GetParentDTO>(p => p.Id == id,
                new List<string> { "User" });
        }

        /// <summary>
        /// Thêm một phụ huynh.
        /// </summary>
        /// <param name="addParentDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddParentDTO addParentDTO)
        {
            return await base.Add<AddParentDTO>(addParentDTO, "GetParentById");
        }

        /// <summary>
        /// Cập nhật một phụ huynh hiện có theo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateParentDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateParentDTO updateParentDTO)
        {
            return await base.Update<UpdateParentDTO>(p => p.Id == id, updateParentDTO);
        }

        /// <summary>
        /// Xóa một phụ huynh hiện có theo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(p => p.Id == id, id);
        }

    }
}
