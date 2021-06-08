using Core.Infrastructure.Exceptions;
using Core.Product.Interfaces;
using DataAccess.Interfaces;
using System;

//classe referente a exclusão de produto por código
namespace Core.Product
{
    public class DeleteProductByCode : IDeleteProductByCode
    {
        IProductRepository _productRepository;

        public DeleteProductByCode(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //método faz uma busca exata de um produto por código e deleta o resultado
        public async void Execute(string Code)
        {
            var result = await _productRepository.GetUnicProductByCodeAsync(Code);

            if (result == null)
            {
                throw new ApiDomainException("Product not found");
            }

            await _productRepository.DeleteAsync(result);
        }
    }
}