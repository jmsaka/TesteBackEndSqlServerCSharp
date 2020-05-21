using FluentValidation;

namespace TestBackEndApi.Domain.Queries.Professor.Get
{
    public class GetProfessorQueryValidator : AbstractValidator<GetProfessorQuery>
    {
        public GetProfessorQueryValidator()
        {
            RuleFor(professor => professor.Cpf).NotNull().WithMessage("Nada de CPF Vazio!!!");
        }
    }
}
