using AutoMapper;
using Desafio_DevWebCloudAWSPractitioner.Application.Gateways;
using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.Gateways;

namespace Desafio_DevWebCloudAWSPractitioner.Application.UseCases
{
    public class StudentInteractor : IStudentGateway
    {
        private readonly IStudentRepositoryGateway _studentRepositoryGateway;
        private readonly IMapper _mapper;

        public StudentInteractor(IStudentRepositoryGateway studentRepositoryGateway, IMapper mapper)
        {
            _studentRepositoryGateway = studentRepositoryGateway;
            _mapper = mapper;
        }

        public Student CreateStudent(Student student)
        {
           var result = _studentRepositoryGateway.CreateStudent(student);
           return _mapper.Map<Student>(result);
        }

        public IEnumerable<Student> GetAll()
        {
            var studentsDomain = new List<Student>();
            var students = _studentRepositoryGateway.GetAll();

            foreach (var student in students) {
                studentsDomain.Add(_mapper.Map<Student>(student));
            }

            return studentsDomain;
        }

        public Student GetById(Guid id)
        {
            var studentRepository = _studentRepositoryGateway.GetbyId(id);
            return _mapper.Map<Student>(studentRepository);
        }

        public Student GetByRa(int ra)
        {
            var studentRepository = _studentRepositoryGateway.GetbyRa(ra);
            return _mapper.Map<Student>(studentRepository);
        }

        public Student Edit(Guid id)
        {
            var studentEdit = _studentRepositoryGateway.Edit(id);
            return _mapper.Map<Student>(studentEdit);
        }

        public bool Delete(Guid id)
        {
            return _studentRepositoryGateway.Delete(id);
        }
    }
}
