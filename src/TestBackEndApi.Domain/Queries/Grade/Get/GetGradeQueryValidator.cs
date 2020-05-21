using FluentValidation;

namespace TestBackEndApi.Domain.Queries.Grade.Get
{
    public class GetGradeQueryValidator : AbstractValidator<GetGradeQuery>
    {
        public GetGradeQueryValidator()
        {
            RuleFor(grade => grade.CodGrade).NotNull().WithMessage("Nada de Código Vazio!!!");
        }
    }
}
