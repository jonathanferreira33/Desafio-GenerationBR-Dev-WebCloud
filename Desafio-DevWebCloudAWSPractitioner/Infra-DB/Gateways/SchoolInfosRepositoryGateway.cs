using Desafio_DevWebCloudAWSPractitioner.Application.Gateways;
using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.Persistence;

namespace Infra_DB.Gateways
{
    public class SchoolInfosRepositoryGateway : SchoolInfosGateway
    {
        private readonly SchoolInfosRepository _schoolInfosRepository;
        public SchoolInfosRepositoryGateway(SchoolInfosRepository schoolInfosRepository)
        {
            _schoolInfosRepository = schoolInfosRepository;
        }
        public SchoolInfos createSchoolInfos(SchoolInfos schoolInfos)
        {
            return _schoolInfosRepository.Save(schoolInfos);
        }
    }
}
