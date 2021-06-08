using Core.Product.Interfaces;
using Core.Model;
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

//classe referente a busca de todos os produtos registrados
namespace Core.Product
{
    public class GetAllProduct : IGetAllProduct
    {
        IProductRepository _productRepository;

        public GetAllProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PaginationResponse<Model.Product>> Execute(int pageSize = 20, int pageIndex = 1, string sort = "", string direction = "")
        {
            List<Model.Product> resultList = new List<Model.Product>();

            var result = await _productRepository.GetAllAsyncPagination(pageSize, pageIndex, sort, direction);

            foreach (var item in result.DataList)
            {
                resultList.Add(item);
            }

            return new PaginationResponse<Model.Product>()
            {
                PageIndex = result.PageIndex,
                PageSize = result.PageSize,
                TotalRecords = result.TotalRecords,
                ResultList = resultList
            };
        }
    }
}
