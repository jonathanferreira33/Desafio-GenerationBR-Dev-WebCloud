using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;

namespace Desafio_DevWebCloudAWSPractitioner.Domain
{
    public record StudentResponse(string Name, int Age, int RA, SchoolInfos SchoolInfos);
}
