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

            RuleFor(model => model.Email)
             .NotEmpty()
             .WithMessage("O Email da pessoa é obrigatório");

            RuleFor(model => model.SocialNumber)
            .NotEmpty()
            .WithMessage("O CPF  é obrigatório");

            RuleFor(model => model.Fone)
            .NotEmpty()
            .WithMessage("O telefone  é obrigatório");

            RuleFor(model => model.ZipCode)
            .NotEmpty()
            .WithMessage("O CEP  é obrigatório");

            RuleFor(model => model.Street)
            .NotEmpty()
            .WithMessage("A rua  é obrigatório");

            RuleFor(model => model.Number)
            .NotEmpty()
            .WithMessage("O número do imóvel  é obrigatório");

            RuleFor(model => model.Neighborhood)
            .NotEmpty()
            .WithMessage("O bairro é obrigatório");

            RuleFor(model => model.City)
            .NotEmpty()
            .WithMessage("A cidade é obrigatório");

            RuleFor(model => model.State)
            .NotEmpty()
            .WithMessage("O estado é obrigatório");

            //RuleFor(model => model.Status)
            //.NotEmpty()
            //.WithMessage("O status é obrigatório");

            return this;
        }

        public PersonValidator UpdatePersonValidator()
        {
            RuleFor(model => model.Name)
            .NotEmpty()
            .WithMessage("O nome da pessoa é obrigatório");

            RuleFor(model => model.Email)
             .NotEmpty()
             .WithMessage("O Email da pessoa é obrigatório");

            RuleFor(model => model.SocialNumber)
            .NotEmpty()
            .WithMessage("O CPF  é obrigatório");

            RuleFor(model => model.Fone)
            .NotEmpty()
            .WithMessage("O telefone  é obrigatório");

            RuleFor(model => model.ZipCode)
            .NotEmpty()
            .WithMessage("O CEP  é obrigatório");

            RuleFor(model => model.Street)
            .NotEmpty()
            .WithMessage("A rua  é obrigatório");

            RuleFor(model => model.Number)
            .NotEmpty()
            .WithMessage("O número do imóvel  é obrigatório");

            RuleFor(model => model.Neighborhood)
            .NotEmpty()
            .WithMessage("O bairro é obrigatório");

            RuleFor(model => model.City)
            .NotEmpty()
            .WithMessage("A cidade é obrigatório");

            RuleFor(model => model.State)
            .NotEmpty()
            .WithMessage("O estado é obrigatório");

            //RuleFor(model => model.Status)
            //.NotEmpty()
            //.WithMessage("O status é obrigatório");

            return this;
        }
    }
}
