using AutoMapper;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Desafio_DevWebCloudAWSPractitioner.Infrastructure.DB.Persistence
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddStudent(StudentEntity studentEnt)
        {
            var lastRA = GetLastRA();

            studentEnt.RA = lastRA.Max().RA++;

            await _context.AddAsync(studentEnt);
            if (_context.SaveChangesAsync().Result != -1)
                return true;
            else
                return false;
        }

        public bool DeleteStudent(Guid id)
        {
            var studentDelete = _context.Students
                 .Single(s => s.Id == id);

            if (studentDelete == null) return false;

            _context.Students.Remove(studentDelete);
            _context.SaveChangesAsync();

            return true;
        }

        public IEnumerable<StudentEntity> GetAll()
        {
            return _context.Students.ToList();
        }

        public StudentEntity GetById(Guid id)
        {
            return _context.Students
                .Single(s => s.Id == id);
        }

        public StudentEntity GetByRA(int ra)
        {
            return _context.Students
                .Single(s => s.RA == ra);
        }

        public IEnumerable<StudentEntity> GetLastRA()
        {
            var select = @"
                SELECT * FROM desafiogenerationbr.students
                ORDER BY (id) DESC 
                LIMIT 1";

            return _context.Students
                .FromSql(FormattableStringFactory.Create(select));
        }

        public bool UpdateStudent(StudentEntity student)
        {
            var studentUpdate = _context.Students.Find(student.Id);

            if (studentUpdate == null) return false;

            _context.Update(student);
            _context.SaveChanges();
            return true;
        }
    }
}
