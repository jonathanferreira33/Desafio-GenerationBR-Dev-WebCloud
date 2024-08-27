using AutoMapper;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DB.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

namespace Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence
{
    public class SchoolInfosRepository : ISchoolInfosRepository
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;


        public SchoolInfosRepository(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public SchoolInfosEntity EditSchoolInfos(StudentEntity student)
        {
            var schoolInfosEntity = _mapper.Map<SchoolInfosEntity>(student.SchoolInfos);
            var query = @"
                UPDATE desafiogenerationbr.schoolinfos
                SET MarksFirstPeriod = @MarksfirstPeriod, MarksSecondPeriod = @MarksSecondPeriod , NameTeache = @NameTeacher , NumberClassroom = @NumberClassroom
                WHERE Id = @ID;
            ";

            var paramsQuery = new
            {
                MarksfirstPeriod = schoolInfosEntity.MarksfirstPeriod,
                MarksSecondPeriod = schoolInfosEntity.MarksSecondPeriod,
                NameTeacher = schoolInfosEntity.NameTeacher,
                NumberClassroom = schoolInfosEntity.NumberClassroom,
                ID = student.Id
            };

            var result = _context.SchoolInfos
                .FromSql(FormattableStringFactory.Create(query, paramsQuery));

            if (result.Count() > 0)
                return schoolInfosEntity;
            else
                throw new SqlTypeException("Erro ao realizar aletações");
        }
    }
}