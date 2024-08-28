using AutoMapper;
using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DB.Persistence;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence;

namespace Desafio_DevWebCloudAWSPractitioner.Infrastructure.Gateways
{
    public class StudentRepositoryGateway : IStudentRepositoryGateway
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentRepositoryGateway(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public StudentEntity CreateStudent(Student student)
        {
            var studentEntity = _mapper.Map<StudentEntity>(student);

            try
            {
                var result = _studentRepository.AddStudent(studentEntity);

                if (result.Result)
                    return studentEntity;
                else
                    throw new Exception("Erro ao criar Estudante");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public StudentEntity Edit(Guid id)
        {
            var student = _studentRepository.GetById(id);

            if (_studentRepository.UpdateStudent(student))
                return student;
            else throw new Exception("Erro ao editar estudante");
        }

        public IEnumerable<StudentEntity> GetAll()
        {
            try
            {
               return _studentRepository.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public StudentEntity GetbyId(Guid id)
        {
            return _studentRepository.GetById(id);
        }

        public StudentEntity GetbyRa(int ra)
        {
            return _studentRepository.GetByRA(ra);
        }

        public bool Delete(Guid id)
        {
            if (_studentRepository.DeleteStudent(id))
                return true;
            else throw new Exception("Erro ao deletar estudante");
        }
    }
}