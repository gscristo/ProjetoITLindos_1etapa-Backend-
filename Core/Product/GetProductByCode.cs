using Core.Product.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//classe para fazer a busca de um produto por código
namespace Core.Product
{
    public class GetProductByCode : IGetProductByCode
    {

        IProductRepository _productRepository;

        public GetProductByCode(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //método que busca o código dentro da lista e usa um laço para criar uma lista de acordo com os resultados encontrados
        public async Task<IEnumerable<Model.Product>> Execute(string Code)
        {

            var result = await _productRepository.GetProductByCodeAsync(Code);

            List<Model.Product> output = new List<Model.Product>();

            foreach (var item in result)
            {
                output.Add(item);
            }

            return output;


        }
    }
}