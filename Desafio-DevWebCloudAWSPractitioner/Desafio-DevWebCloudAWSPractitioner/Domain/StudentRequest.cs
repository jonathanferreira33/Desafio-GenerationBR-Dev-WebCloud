using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;

namespace Desafio_DevWebCloudAWSPractitioner.Domain
{
    public record  StudentRequest(string Name, int Age, SchoolInfos SchoolInfos);
}
