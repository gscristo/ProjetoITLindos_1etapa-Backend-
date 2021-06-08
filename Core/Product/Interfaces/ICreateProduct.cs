using System.Threading.Tasks;

namespace Core.Product.Interfaces
{
    public interface ICreateProduct
    {
        Task<Model.Product> Execute(Model.Product product);
    }
}