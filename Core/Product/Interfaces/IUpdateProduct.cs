using System.Threading.Tasks;

namespace Core.Product.Interfaces
{
    public interface IUpdateProduct
    {
        Task<bool> Execute(Model.Product product);
    }
}

