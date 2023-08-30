using SmartEdu.Entities;
using SmartEdu.Repository;

namespace SmartEdu.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Teacher> TeacherRepository { get; }
        IGenericRepository<Student> StudentRepository { get; }
        IGenericRepository<Parent> ParentRepository { get; }
        IGenericRepository<Document> DocumentRepository { get; }
        IGenericRepository<Subject> SubjectRepository { get; }
        Task Save();
    }
}
