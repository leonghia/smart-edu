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
        IGenericRepository<Exam> ExamRepository { get; }
        IGenericRepository<ExtraClass> ExtraClassRepository { get; }
        IGenericRepository<MainClass> MainClassRepository { get; }
        Task Save();
    }
}
