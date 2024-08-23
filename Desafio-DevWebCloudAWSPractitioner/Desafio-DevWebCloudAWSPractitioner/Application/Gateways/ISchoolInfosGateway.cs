using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;

namespace Desafio_DevWebCloudAWSPractitioner.Application.Gateways
{
    public interface ISchoolInfosGateway
    {
        SchoolInfos createSchoolInfos(SchoolInfos schoolInfos);
    }
}
