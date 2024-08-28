using Microsoft.EntityFrameworkCore;

namespace Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence
{
    [Index(nameof(RA))]
    public class StudentEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public SchoolInfosEntity SchoolInfos { get; set; }
        public int RA { get; set; }
        public DateTime RegistrationDate { get; private set; }


        public StudentEntity(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            RegistrationDate = DateTime.Now;
        }
    }
}