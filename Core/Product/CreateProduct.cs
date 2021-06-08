using Core.Infrastructure.Exceptions;
using Core.Product.Interfaces;
using DataAccess.Interfaces;
using System.Threading.Tasks;
using Core.Product.Validators;
using System.Linq;
using System.Collections.Generic;

//classe referente a criação de um novo produto
namespace Core.Product
{
    public class CreateProduct : ICreateProduct
    {
        IProductRepository _productRepository;
        private readonly ProductValidator _productValidator;

        public CreateProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _productValidator = ProductValidator.Validate().CreateProductValidator();
        }

        public async Task<Model.Product> Execute(Model.Product product)
        {
            var ProductValidated = _productValidator.Validate(product);

            if (!ProductValidated.IsValid)
            {
                throw new ApiDomainException(ProductValidated.Errors);
            }
            //inicio da validação de código existe
            var allProducts = await _productRepository.GetAllAsync();

            var found = allProducts.ToList().Find(x => x.Code == product.Code);

            if (found != null)
            {
                throw new ApiDomainException("Este produto ja está cadastrado");
            }
            //fim da validação de código existe

            //inicio da condição das unidades estipuladas
            string[] unitList = new string[5] { "PC", "KG", "ML", "CJ", "UN" };

            var unitFound = unitList.FirstOrDefault(x => x == product.Unit);

            if (unitFound == null)
            {
                throw new ApiDomainException("Insira uma unidade válida");
            }
            //fim da condição das unidades estipuladas
            product.ProductId = await _productRepository.InsertAsync(product);

            return product;
        }
    }
}
