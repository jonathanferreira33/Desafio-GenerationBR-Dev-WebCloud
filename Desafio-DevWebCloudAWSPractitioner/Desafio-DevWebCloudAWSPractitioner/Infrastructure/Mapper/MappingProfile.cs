using AutoMapper;
using Desafio_DevWebCloudAWSPractitioner.Domain;
using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence;

namespace Desafio_DevWebCloudAWSPractitioner.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentEntity, Student>();
            CreateMap<StudentEntity, StudentRequest>();
            CreateMap<StudentEntity, StudentResponse>();
            CreateMap<StudentRequest, StudentEntity>();
            CreateMap<StudentRequest, Student>();
            CreateMap<Student, StudentEntity>();
            CreateMap<Student, StudentRequest>();
            CreateMap<Student, StudentResponse>();
            CreateMap<SchoolInfos, SchoolInfosEntity>();

            //.ForMember(dest => dest.Variants, opt => opt.Ignore());
        }
    }
}
