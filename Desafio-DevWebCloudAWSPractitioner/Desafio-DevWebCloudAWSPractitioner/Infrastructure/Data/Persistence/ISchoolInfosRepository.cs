using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence;

namespace Desafio_DevWebCloudAWSPractitioner.Infrastructure.DB.Persistence
{
    public interface ISchoolInfosRepository
    {
        SchoolInfosEntity EditSchoolInfos(StudentEntity student);
    }
}
