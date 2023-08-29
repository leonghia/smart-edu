﻿using SmartEdu.Data;
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
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IGenericRepository<Teacher> TeacherRepository => _teacherRepository ??= new GenericRepository<Teacher>(_context);

        public IGenericRepository<Student> StudentRepository => _studentRepository ??= new GenericRepository<Student>(_context);

        public IGenericRepository<Parent> ParentRepository => _parentRepository ??= new GenericRepository<Parent>(_context);

        public IGenericRepository<Document> DocumentRepository => _documentRepository ??= new GenericRepository<Document>(_context);

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
