using Core.Product.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Threading.Tasks;

//classe que busca um produto por Id
namespace Core.Product
{
    public class GetProductById : IGetProductById
    {

        IProductRepository _productRepository;

        public GetProductById(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Model.Product> Execute(Guid productId)
        {
            return await _productRepository.GetByIdAsync(productId);
        }
    }
}
