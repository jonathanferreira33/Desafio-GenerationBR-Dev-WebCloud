using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence;

namespace Desafio_DevWebCloudAWSPractitioner.Infrastructure.Gateways
{
    public interface IStudentRepositoryGateway
    {
        StudentEntity CreateStudent(Student student);
        IEnumerable<StudentEntity> GetAll();
        StudentEntity GetbyRa(int ra);
        StudentEntity GetbyId(Guid id);
        StudentEntity Edit(Guid id);
        bool Delete(Guid id);
    }
}
