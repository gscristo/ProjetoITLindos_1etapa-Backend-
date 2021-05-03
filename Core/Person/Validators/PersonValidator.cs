using FluentValidation;

namespace Core.Person.Validators
{
    public class PersonValidator : AbstractValidator<Model.Person>
    {
        public static PersonValidator Validate()
        {
            return new PersonValidator();
        }

        public PersonValidator CreatePersonValidator()
        {
            RuleFor(model => model.Name)
            .NotEmpty()
            .WithMessage("O nome da pessoa é obrigatório");

            return this;
        }

        public PersonValidator UpdatePersonValidator()
        {
            RuleFor(model => model.PersonId)
            .NotEmpty()
            .WithMessage("O Id da pessoa é obrigatório");

            return this;
        }
    }
}
