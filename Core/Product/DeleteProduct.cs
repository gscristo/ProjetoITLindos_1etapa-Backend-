using Core.Infrastructure.Exceptions;
using Core.Product.Interfaces;
using DataAccess.Interfaces;
using System;

//classe referente a exclusão de produto
namespace Core.Product
{
    public class DeleteProduct : IDeleteProduct
    {
        IProductRepository _productRepository;

        public DeleteProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //metodo que faz uma busca por Id e deleta o resultado
        public async void Execute(Guid productId)
        {
            var result = await _productRepository.GetByIdAsync(productId);

            if (result == null)
            {
                throw new ApiDomainException("Product not found");
            }

            await _productRepository.DeleteAsync(result);
        }
    }
}
