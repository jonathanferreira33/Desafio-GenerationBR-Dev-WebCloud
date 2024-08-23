using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;

namespace Desafio_DevWebCloudAWSPractitioner.Application.Gateways
{
    public interface IStudentGateway
    {
        Student CreateStudent(Student student);
        IEnumerable<Student> GetAll();
        Student GetById(Guid id);
        Student GetByRa(int ra);
        Student Edit(Guid id);
        bool Delete(Guid id);
    }
}
