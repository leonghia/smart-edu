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
        IGenericRepository<ExtraClass> ExtraClassRepository { get; }
        IGenericRepository<MainClass> MainClassRepository { get; }
        IGenericRepository<Subject> SubjectRepository { get; }
        IGenericRepository<ExtraClassStudent> ExtraClassStudentRepository { get; }
        IGenericRepository<EcBookmark> EcBookmarkRepository { get; }
        IGenericRepository<ExtraClassEcBookmark> ExtraClassEcBookmarkRepository { get; }
        IGenericRepository<Mark> MarkRepository { get; }
        IGenericRepository<Timetable> TimetableRepository { get; }
        IGenericRepository<AcademicProgress> AcademicProgressRepository { get; }
        IGenericRepository<AcademicTracker> AcademicTrackerRepository { get; }
        Task Save();
    }
}
