using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence;

namespace Desafio_DevWebCloudAWSPractitioner.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int RA { get; set; }
        public SchoolInfos SchoolInfos { get; set; }
    }
}
