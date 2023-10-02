using SmartEdu.Data;
using SmartEdu.Entities;
using SmartEdu.Repository;

namespace SmartEdu.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IGenericRepository<Teacher> _teacherRepository;
        private IGenericRepository<Student> _studentRepository;
        private IGenericRepository<Parent> _parentRepository;
        private IGenericRepository<Document> _documentRepository;
        private IGenericRepository<ExtraClass> _extraClassRepository;
        private IGenericRepository<MainClass> _mainClassRepository;
        private IGenericRepository<Subject> _subjectRepository;
        private IGenericRepository<ExtraClassStudent> _extraClassStudentRepository;
        private IGenericRepository<EcBookmark> _ecBookmarkRepository;
        private IGenericRepository<ExtraClassEcBookmark> _extraClassEcBookmarkRepository;
        private IGenericRepository<Mark> _markRepository;
        private IGenericRepository<Timetable> _timetableRepository;
        private IGenericRepository<AcademicProgress> _academicProgressRepository;
        private IGenericRepository<AcademicTracker> _academicTrackerRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IGenericRepository<Teacher> TeacherRepository => _teacherRepository ??= new GenericRepository<Teacher>(_context);

        public IGenericRepository<Student> StudentRepository => _studentRepository ??= new GenericRepository<Student>(_context);

        public IGenericRepository<Parent> ParentRepository => _parentRepository ??= new GenericRepository<Parent>(_context);

        public IGenericRepository<Document> DocumentRepository => _documentRepository ??= new GenericRepository<Document>(_context);
        public IGenericRepository<Subject> SubjectRepository => _subjectRepository ??= new GenericRepository<Subject>(_context);
        public IGenericRepository<ExtraClass> ExtraClassRepository => _extraClassRepository ??= new GenericRepository<ExtraClass>(_context);
        public IGenericRepository<MainClass> MainClassRepository => _mainClassRepository ??= new GenericRepository<MainClass>(_context);
        public IGenericRepository<ExtraClassStudent> ExtraClassStudentRepository => _extraClassStudentRepository ??= new GenericRepository<ExtraClassStudent>(_context);
        public IGenericRepository<EcBookmark> EcBookmarkRepository => _ecBookmarkRepository ??= new GenericRepository<EcBookmark>(_context);
        public IGenericRepository<ExtraClassEcBookmark> ExtraClassEcBookmarkRepository => _extraClassEcBookmarkRepository ??= new GenericRepository<ExtraClassEcBookmark>(_context);
        public IGenericRepository<Mark> MarkRepository => _markRepository ??= new GenericRepository<Mark>(_context);
        public IGenericRepository<Timetable> TimetableRepository => _timetableRepository ??= new GenericRepository<Timetable>(_context);

        public IGenericRepository<AcademicProgress> AcademicProgressRepository => _academicProgressRepository ??= new GenericRepository<AcademicProgress>(_context);

        public IGenericRepository<AcademicTracker> AcademicTrackerRepository => _academicTrackerRepository ??= new GenericRepository<AcademicTracker>(_context);

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
