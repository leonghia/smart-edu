using SmartEdu.Models;
using System.Collections;
using System.Linq.Expressions;
using X.PagedList;

namespace SmartEdu.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {       
        int Count(Func<TEntity, bool> filter = null);
        Task<IEnumerable<TEntity>> GetAll(RequestParams requestParams, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<string> includeProperties = null);
        Task<IPagedList<TEntity>> GetPagedList(RequestParams requestParams, List<string> includeProperties = null);
        Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter, List<string> includeProperties = null);
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task Delete(object id);
        Task Delete(object id1, object id2);
        void Update(TEntity entityToUpdate);
    }
}
