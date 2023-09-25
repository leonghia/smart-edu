using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartEdu.Data;
using SmartEdu.DTOs.DocumentDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using X.PagedList;

namespace SmartEdu.Services.DocumentService;

public class DocumentService : IDocumentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly DbSet<Document> _table;

    public DocumentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _table = _context.Set<Document>();
    }

    public async Task<ServerResponse<IPagedList<GetDocumentDTO>>> GetAll(RequestParams requestParams, FilterDocumentParams filterDocumentParams, Func<IQueryable<Document>, IOrderedQueryable<Document>> orderBy = null, List<string> includeProperties = null)
    {
        var serverReponse = new ServerResponse<IPagedList<GetDocumentDTO>>();
        IQueryable<Document> query = _table;
        
        if (filterDocumentParams.SubjectId != 0)
        {
            query = query.Where(d => d.Teacher.SubjectId == filterDocumentParams.SubjectId);
        }
        if (filterDocumentParams.FromNumbersOfRating != 0 && filterDocumentParams.ToNumbersOfRating != 0)
        {
            query = query.Where(d => d.NumbersOfRating >= filterDocumentParams.FromNumbersOfRating && d.NumbersOfRating <= filterDocumentParams.ToNumbersOfRating);
        }
        if (filterDocumentParams.FromRating != 0 && filterDocumentParams.ToRating != 0)
        {
            query = query.Where(d => d.Rating >= filterDocumentParams.FromRating && d.Rating <= filterDocumentParams.ToRating);
        }

        if (includeProperties is not null)
        {
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
        }

        if (orderBy is not null) {
            query = orderBy(query);
        }

        var documents = await query.AsNoTracking().ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        var documentsDTO = documents.Select(d => _mapper.Map<GetDocumentDTO>(d));
        serverReponse.Data = documentsDTO;
        return serverReponse;
    }
}