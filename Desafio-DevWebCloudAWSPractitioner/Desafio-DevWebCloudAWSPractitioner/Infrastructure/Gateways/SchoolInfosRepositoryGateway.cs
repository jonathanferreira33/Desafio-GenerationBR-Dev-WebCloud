using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DB.Persistence;

namespace Desafio_DevWebCloudAWSPractitioner.Infrastructure.Gateways
{
    public class SchoolInfosRepositoryGateway : ISchoolInfosRepositoryGateway
    {
        private readonly ISchoolInfosRepository _schoolInfosRepository;
        public SchoolInfosRepositoryGateway(ISchoolInfosRepository schoolInfosRepository)
        {
            _schoolInfosRepository = schoolInfosRepository;
        }
        public SchoolInfos createSchoolInfos(SchoolInfos schoolInfos)
        {
            throw new NotImplementedException();

            //return _schoolInfosRepository.Save(schoolInfos);
        }
    }
}
