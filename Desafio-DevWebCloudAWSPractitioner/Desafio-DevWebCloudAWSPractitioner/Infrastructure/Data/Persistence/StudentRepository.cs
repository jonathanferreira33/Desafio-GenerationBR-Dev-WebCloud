using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            int lastRA = GetLastRA();
            lastRA++;

            studentEnt.RA = lastRA;

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
            return _context.Students.Include(infos => infos.SchoolInfos).ToList();
        }

        public StudentEntity GetById(Guid id)
        {
            var studentEntity = _context.Students
                .Single(s => s.Id == id);
            return studentEntity;
        }

        public StudentEntity GetByRA(int ra)
        {
            return _context.Students
                .Single(s => s.RA == ra);
        }

        public int GetLastRA()
        {
            var select = @"
                SELECT * FROM desafiogenerationbr.students
                ORDER BY (id) DESC 
                LIMIT 1";

            var result = _context.Students
                .FromSql(FormattableStringFactory.Create(select));

            if (result.Count() == 0)
                return 1000;

            return result.Select(e => e.RA).Single();
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
