using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence
{
    public class SchoolInfosEntity
    {
 
        public Guid Id { get; private set; }
        public double MarksfirstPeriod { get; set; }
        public double MarksSecondPeriod { get; set; }
        public string NameTeacher { get; set; }
        public int NumberClassroom { get; set; }
        public StudentEntity Student { get; set; }
        
        [ForeignKey("Student")]
        public Guid StudentId { get; set; }

        public SchoolInfosEntity()
        {
            Id = new Guid();
        }
    }
}
