using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestBackEndApi.Domain.Commands.Alunos.Post;
using TestBackEndApi.Domain.Commands.Grades.Post;
using TestBackEndApi.Domain.Commands.Matriculas.Post;
using TestBackEndApi.Domain.Commands.Professores.Post;
using TestBackEndApi.Domain.Queries.Aluno.Get;
using TestBackEndApi.Domain.Queries.Grade.Get;
using TestBackEndApi.Domain.Queries.Professor.Get;

namespace TestBackEndApi.Api.Controllers
{
    [ApiController]
    [Route("school")]
    public class SchoolController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchoolController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("alunos")]
        public async Task<IActionResult> Alunos()
        {
            var response = await _mediator.Send(new GetAlunoQuery());
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet]
        [Route("professor")]
        public async Task<IActionResult> Professor(string cpf)
        {
            var response = await _mediator.Send(new GetProfessorQuery() { Cpf = cpf });
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet]
        [Route("grades")]
        public async Task<IActionResult> Grades()
        {
            var response = await _mediator.Send(new GetProfessorQuery());
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet]
        [Route("grade")]
        public async Task<IActionResult> Grade(long codGrade)
        {
            var response = await _mediator.Send(new GetGradeQuery() { CodGrade = codGrade });
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpPost]
        [Route("aluno")]
        public async Task<IActionResult> Aluno([FromBody] AlunoCommand aluno)
        {
            var response = await _mediator.Send(aluno);
            if (!response) return NotFound();
            return Ok(response);
        }

        [HttpPost]
        [Route("professor")]
        public async Task<IActionResult> Professor([FromBody] ProfessorCommand professor)
        {
            var response = await _mediator.Send(professor);
            if (!response) return NotFound();
            return Ok(response);
        }

        [HttpPost]
        [Route("grade")]
        public async Task<IActionResult> Grade([FromBody] GradeCommand grade)
        {
            var response = await _mediator.Send(grade);
            if (!response) return NotFound();
            return Ok(response);
        }

        [HttpPost]
        [Route("matricula")]
        public async Task<IActionResult> Matricula([FromBody] PostMatriculaCommand matricula)
        {
            var response = await _mediator.Send(matricula);
            if (!response) return NotFound();
            return Ok(response);
        }

        [HttpDelete]
        [Route("matricula")]
        public async Task<IActionResult> DesMatricula([FromBody] DeleteMatriculaCommand matricula)
        {
            var response = await _mediator.Send(matricula);
            if (!response) return NotFound();
            return Ok(response);
        }
    }
}