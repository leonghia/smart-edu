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
        private IGenericRepository<Exam> _examRepository;
        private IGenericRepository<ExtraClass> _extraClassRepository;
        private IGenericRepository<MainClass> _mainClassRepository;
        private IGenericRepository<Subject> _subjectRepository;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IGenericRepository<Teacher> TeacherRepository => _teacherRepository ??= new GenericRepository<Teacher>(_context);

        public IGenericRepository<Student> StudentRepository => _studentRepository ??= new GenericRepository<Student>(_context);

        public IGenericRepository<Parent> ParentRepository => _parentRepository ??= new GenericRepository<Parent>(_context);

        public IGenericRepository<Document> DocumentRepository => _documentRepository ??= new GenericRepository<Document>(_context);
        public IGenericRepository<Subject> SubjectRepository => _subjectRepository ??= new GenericRepository<Subject>(_context);

        public IGenericRepository<Exam> ExamRepository => _examRepository ??= new GenericRepository<Exam>(_context);

        public IGenericRepository<ExtraClass> ExtraClassRepository => _extraClassRepository ??= new GenericRepository<ExtraClass>(_context);

        public IGenericRepository<MainClass> MainClassRepository => _mainClassRepository ??= new GenericRepository<MainClass>(_context);

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
