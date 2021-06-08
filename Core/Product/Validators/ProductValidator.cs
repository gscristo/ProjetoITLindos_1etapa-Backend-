using FluentValidation;

namespace Core.Product.Validators
{
    public class ProductValidator : AbstractValidator<Model.Product>
    {
        public static ProductValidator Validate()
        {
            return new ProductValidator();
        }

        public ProductValidator CreateProductValidator()
        {
            RuleFor(model => model.Code)
            .NotEmpty()
            .WithMessage("O codigo do produto é obrigatório");

            RuleFor(model => model.Name)
            .NotEmpty()
            .WithMessage("O nome do produto é obrigatório");


            RuleFor(model => model.Unit)
            .NotEmpty()
            .WithMessage("A unidade do produto é obrigatório");


            RuleFor(model => model.Value)
            .NotEmpty()
            .WithMessage("O codigo do produto é obrigatório");

            return this;
        }

        public ProductValidator UpdateProductValidator()
        {
            RuleFor(model => model.ProductId)
            .NotEmpty()
            .WithMessage("O Id do produto é obrigatório");

            RuleFor(model => model.Code)
            .NotEmpty()
            .WithMessage("O codigo do produto é obrigatório");

            RuleFor(model => model.Name)
            .NotEmpty()
            .WithMessage("O nome do produto é obrigatório");

            RuleFor(model => model.Unit)
            .NotEmpty()
            .WithMessage("A unidade do produto é obrigatório");

            RuleFor(model => model.Value)
            .NotEmpty()
            .WithMessage("O valor do produto é obrigatório");

            return this;
        }
    }
}
