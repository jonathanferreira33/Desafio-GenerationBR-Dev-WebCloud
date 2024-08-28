using AutoMapper;
using Desafio_DevWebCloudAWSPractitioner.Application.Gateways;
using Desafio_DevWebCloudAWSPractitioner.Domain;
using Desafio_DevWebCloudAWSPractitioner.Domain.Entities;
using Desafio_DevWebCloudAWSPractitioner.Helpers.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_DevWebCloudAWSPractitioner.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentGateway _studentGateway;
        private readonly IMapper _mapper;

        public StudentController(IStudentGateway studentGateway, IMapper mapper)
        {
            _studentGateway = studentGateway;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {

            try
            {
                var students = _studentGateway.GetAll();

                return Ok(new Result<List<Student>>(
                    students.ToList(), "OK", 200)
                    );
            }
            catch (Exception e)
            {
                return StatusCode(
                   500,
                   new Result<Object>(e.Message, 500)
               );
            }
        }

        [HttpGet("/studentid/{id}")]
        public ActionResult GetStudent(Guid id)
        {
            try
            {
                var student = _studentGateway.GetById(id);
                return Ok(new Result<Student>(student, 200));
            }
            catch (Exception e)
            {
                return StatusCode(
                   500,
                   new Result<Object>(e.Message, 500)
                );
            }
        }

        [HttpGet("/studentra/{ra}")]
        public ActionResult GetStudentbyRa(int ra)
        {
            try
            {
                var student = _studentGateway.GetByRa(ra);
                return Ok(
                    new Result<StudentResponse>(
                        _mapper.Map<StudentResponse>(student), 200
                    )
                );
            }
            catch (Exception e)
            {
                return StatusCode(
                   500,
                   new Result<Object>(e.Message, 500)
               );
            }
        }

        [HttpPost]
        public ActionResult createStudent(StudentRequest request)
        {
            try
            {
                var student = _mapper.Map<Student>(request);
                var newStudent = _studentGateway.CreateStudent(student);

                return Ok(
                    new Result<StudentResponse>(
                        _mapper.Map<StudentResponse>(newStudent),
                        $"Alune {newStudent.Name}, Registro Acadêmico: {newStudent.RA}, cadastrado com sucesso.",
                        200)
                    );
            }
            catch (Exception e)
            {
                return StatusCode(
                    500,
                    new Result<Object>(e.Message, 500)
                );
            }
        }

        [HttpPut]
        public ActionResult EditStudent(Guid id)
        {
            try
            {
                var studentEdit = _studentGateway.GetById(id);
                if (studentEdit == null)
                    return StatusCode(
                       404,
                       new Result<Object>("Estudante mão encontrado", 404)
                    );

                _studentGateway.Edit(studentEdit.Id);

                return Ok(
                    new Result<StudentResponse>(
                        _mapper.Map<StudentResponse>(studentEdit), 200
                    )
                );

            }
            catch (Exception e)
            {
                return StatusCode(
                   500,
                   new Result<Object>(e.Message, 500)
                );
            }

        }

        [HttpDelete]
        public ActionResult DeleteStudent(Guid id)
        {
            try
            {
                var studentDelete = _studentGateway.GetById(id);
                if (studentDelete == null)
                    return StatusCode(
                       404,
                       new Result<Object>("Estudante não encontrado", 404)
                    );

                if (_studentGateway.Delete(studentDelete.Id))
                    return StatusCode(204,
                        new Result<Object>(
                            $"Estudante {studentDelete.Name} deletado com sucesso", 204
                        )
                    );
                else
                    return StatusCode(500,
                         new Result<Object>(
                             $"Erro ao deletar {studentDelete.Name}", 500
                         )
                    );
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