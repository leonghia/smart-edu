using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.DocumentDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.UnitOfWork;


namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : BaseController<Document>
    {
        public DocumentController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        /// <summary>
        /// Truy xuất toàn bộ tài liệu.
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams requestParams)
        {
            return await base.GetAll<GetDocumentDTO>(requestParams, null, null, new List<string> { "Teacher" });
        }

        /// <summary>
        /// Truy xuất dữ liệu theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetDocumentById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await base.GetSingle<GetDocumentDTO>(d => d.Id == id, new List<string> { "Teacher"});
        }

        /// <summary>
        /// Thêm mới 1 tài liệu
        /// </summary>
        /// <param name="addDocumentDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddDocumentDTO addDocumentDTO)
        {
            return await base.Add(addDocumentDTO, "GetDocumentById");
        }

        /// <summary>
        /// Cập nhật 1 tài liệu hiện có theo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDocumentDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDocumentDTO updateDocumentDTO)
        {
            return await base.Update<UpdateDocumentDTO>(d => d.Id == id, updateDocumentDTO);
        }

        /// <summary>
        /// Xóa 1 tài liệu hiện có theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(d => d.Id == id, id);
        }
    }
}
