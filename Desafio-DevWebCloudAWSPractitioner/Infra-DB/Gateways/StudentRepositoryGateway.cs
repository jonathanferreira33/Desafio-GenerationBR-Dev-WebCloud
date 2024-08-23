using Desafio_DevWebCloudAWSPractitioner.Application.Gateways;
using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.Persistence;

namespace Infra_DB.Gateways
{
    public class StudentRepositoryGateway : StudentGateway
    {
        private readonly StudentRepository _studentRepository;

        public StudentRepositoryGateway(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public Student createStudent(Student student)
        {
            return _studentRepository.Save(student);
        }
    }
}
