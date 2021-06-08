using Core.Product.Interfaces;
using Core.Product.Validators;
using Core.Infrastructure.Exceptions;
using DataAccess.Interfaces;
using System.Threading.Tasks;
using System.Linq;

//classe para atualização de dados de um produto já cadastrado
namespace Core.Product
{
    public class UpdateProduct : IUpdateProduct
    {
        IProductRepository _productRepository;
        private readonly ProductValidator _productValidator;

        public UpdateProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _productValidator = ProductValidator.Validate().UpdateProductValidator();
        }
        //nesse ponto são feitas as validações estipuladas
        public async Task<bool> Execute(Model.Product product)
        {
            var productValidated = _productValidator.Validate(product);

            if (!productValidated.IsValid)
            {
                throw new ApiDomainException(productValidated.Errors);
            }
            //aqui é feita a validação das unidades estipuladas
            string[] unitList = new string[5] { "PC", "KG", "ML", "CJ", "UN" };

            var unitFound = unitList.FirstOrDefault(x => x == product.Unit);

            if (unitFound == null)
            {
                throw new ApiDomainException("Insira uma unidade válida");
            }
            return await _productRepository.UpdateAsync(product);
        }
    }
}
