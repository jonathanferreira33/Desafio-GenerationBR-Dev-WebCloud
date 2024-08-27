using AutoMapper;
using Desafio_DevWebCloudAWSPractitioner.Application.Gateways;
using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DB.Persistence;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence;

namespace Desafio_DevWebCloudAWSPractitioner.Aplicacao.UseCases
{
    public class SchoolInfosInteractor : ISchoolInfosGateway
    {
        private readonly IMapper _mapper;
        private readonly ISchoolInfosRepository _schoolInfosRepository;

        public SchoolInfosInteractor(IMapper mapper, ISchoolInfosRepository schoolInfosRepository)
        {
            _mapper = mapper;
            _schoolInfosRepository = schoolInfosRepository;
        }

        public SchoolInfos EditSchoolInfos(Student student, SchoolInfos infos)
        {
            var schoolInfosEntity = _mapper.Map<SchoolInfosEntity>(infos);
            var studentEntity = _mapper.Map<StudentEntity>(student);
            studentEntity.SchoolInfos = schoolInfosEntity;

            _schoolInfosRepository.EditSchoolInfos(studentEntity);

            return infos;

        }
    }
}
