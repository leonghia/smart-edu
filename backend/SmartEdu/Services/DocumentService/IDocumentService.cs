using SmartEdu.DTOs.DocumentDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using X.PagedList;

namespace SmartEdu.Services.DocumentService;

public interface IDocumentService
{
    Task<ServerResponse<IPagedList<GetDocumentDTO>>> GetAll(RequestParams requestParams, FilterDocumentParams filterDocumentParams, Func<IQueryable<Document>, IOrderedQueryable<Document>> orderBy = null, List<string> includeProperties = null);

    Task<ServerResponse<object>> GetCountOfEachSubject();
}