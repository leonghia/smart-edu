using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using SmartEdu.Data;
using SmartEdu.Models;
using System.Linq.Expressions;
using X.PagedList;

namespace SmartEdu.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _table;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        public int Count(Func<TEntity, bool> filter = null)
        {
            if (filter is not null) return _table.Count(filter);
            return _table.Count();
        }

        public async Task Delete(object id)
        {
            TEntity entityToDelete = await _table.FindAsync(id);
            _table.Remove(entityToDelete);
        }     

        public async Task Delete(object id1, object id2)
        {
            TEntity entityToDelete = await _table.FindAsync(id1, id2);
            _table.Remove(entityToDelete);
        } 

        public async Task<IEnumerable<TEntity>> GetAll(RequestParams requestParams, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<string> includeProperties = null)
        {
            IQueryable<TEntity> query = _table;

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            if (includeProperties is not null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy is not null)
            {
                query = orderBy(query);
            }

            if (requestParams is not null)
            {
                return await query.AsNoTracking().ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TEntity>> GetPagedList(RequestParams requestParams, List<string> includeProperties = null)
        {
            IQueryable<TEntity> query = _table;           

            if (includeProperties is not null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }          

            return await query.AsNoTracking().ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        }

        public async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter, List<string> includeProperties = null)
        {
            IQueryable<TEntity> query = _table;
            if (includeProperties is not null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public void Update(TEntity entityToUpdate)
        {
            _table.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
