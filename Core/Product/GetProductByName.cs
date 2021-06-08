using Core.Product.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//classe referente a busca de produto por nome
namespace Core.Product
{
    public class GetProductByName : IGetProductByName
    {

        IProductRepository _productRepository;

        public GetProductByName(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //método busca o nome digitado no banco e cria uma lista usando um laço atraves dos resultados encontrados.
        public async Task<IEnumerable<Model.Product>> Execute(string Name)
        {
            var result = await _productRepository.GetByNameAsync(Name);

            List<Model.Product> output = new List<Model.Product>();

            foreach (var item in result)
            {
                output.Add(item);
            }

            return output;


        }
    }
}

