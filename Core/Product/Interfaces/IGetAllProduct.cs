using Core.Model;
using System.Threading.Tasks;

namespace Core.Product.Interfaces
{
    public interface IGetAllProduct
    {
        Task<PaginationResponse<Model.Product>> Execute(int pageSize = 20, int pageIndex = 1, string sort = "", string direction = "");
    }
}