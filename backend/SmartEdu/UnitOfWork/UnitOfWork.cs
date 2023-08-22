using SmartEdu.Data;
using SmartEdu.Entities;
using SmartEdu.Repository;

namespace SmartEdu.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;             

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }          

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
