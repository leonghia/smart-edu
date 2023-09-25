using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartEdu.DTOs.DocumentDTO;
using SmartEdu.Entities;
using SmartEdu.Helpers.FilterParamsAppender;
using SmartEdu.Models;
using SmartEdu.Services.DocumentService;
using SmartEdu.UnitOfWork;


namespace SmartEdu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : BaseController<Document>
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IUnitOfWork unitOfWork, IMapper mapper, IDocumentService documentService) : base(unitOfWork, mapper)
        {
            _documentService = documentService;
        }

        /// <summary>
        /// Đếm tổng số tài liệu mà thỏa mãn tiêu chí lọc
        /// </summary>
        /// <param name="filterDocumentParams"></param>
        /// <returns></returns>
        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] FilterDocumentParams filterDocumentParams)
        {
            var func = FilterParamsAppender.AppendDocumentFilterParams(filterDocumentParams);
            return await base.Count(func);
        }

        /// <summary>
        /// Đếm tổng số tài liệu của từng môn học.
        /// </summary>
        /// <returns></returns>
        [HttpGet("count-each")]
        public async Task<IActionResult> CountEach()
        {
            var response = await _documentService.GetCountOfEachSubject();
            return Ok(response);
        }

        /// <summary>
        /// Truy xuất toàn bộ tài liệu.
        /// </summary>
        /// <param name="requestParams"></param>
        /// <param name="filterDocumentParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParams requestParams, [FromQuery] FilterDocumentParams filterDocumentParams)
        {
            var response = await _documentService.GetAll(requestParams, filterDocumentParams, null, new List<string> {"Teacher.User", "Teacher.Subject"});
            return Ok(response);
        }

        /// <summary>
        /// Truy xuất 1 tài liệu hiện có theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetDocumentById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return await base.GetSingle<GetDocumentDTO>(d => d.Id == id, new List<string> { "Teacher.User", "Teacher.Subject"});
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
