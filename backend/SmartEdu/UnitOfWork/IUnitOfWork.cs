using SmartEdu.Entities;
using SmartEdu.Repository;

namespace SmartEdu.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        
        Task Save();
    }
}
