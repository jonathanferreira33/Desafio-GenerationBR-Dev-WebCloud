using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence;

namespace Desafio_DevWebCloudAWSPractitioner.Infrastructure.DB.Persistence
{
    public interface IStudentRepository
    {
        IEnumerable<StudentEntity> GetAll();
        StudentEntity GetById(Guid id);
        StudentEntity GetByRA(int ra);
        Task<bool> AddStudent(StudentEntity student);
        bool UpdateStudent(StudentEntity student);
        bool DeleteStudent(Guid id);
        IEnumerable<StudentEntity> GetLastRA();
    }
}
