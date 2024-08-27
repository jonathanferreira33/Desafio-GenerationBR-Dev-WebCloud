using AutoMapper;
using Desafio_DevWebCloudAWSPractitioner.Application.Gateways;
using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;
using Desafio_DevWebCloudAWSPractitioner.Helpers.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_DevWebCloudAWSPractitioner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolInfosContoller : ControllerBase
    {
        private readonly IStudentGateway _studentGateway;
        private readonly ISchoolInfosGateway _schoolInfosGateway;
        private readonly IMapper _mapper;

        public SchoolInfosContoller(IStudentGateway studentGateway,ISchoolInfosGateway schoolInfosGateway, IMapper mapper)
        {
            _schoolInfosGateway = schoolInfosGateway;
            _studentGateway = studentGateway;
            _mapper = mapper;
        }

        [HttpPut("/{id}")]
        public ActionResult EditSchoolInfos(Guid id, SchoolInfos infos)
        {
            try
            {
                var student = _studentGateway.GetById(id);
                if (student == null)
                    return StatusCode(404, new Result<Object>("Estudante Não encontrado", 404));

                _schoolInfosGateway.EditSchoolInfos(student, infos);

                return StatusCode(201, new Result<Object>("Dados atualizados com sucesso", 201));

            }
            catch (Exception e)
            {
                return StatusCode(
                   500,
                   new Result<Object>(e.Message, 500)
                );
            }
        }
    }
}
