using System;
using System.Threading.Tasks;

namespace Core.Product.Interfaces
{
    public interface IGetProductById
    {
        Task<Model.Product> Execute(Guid productId);
    }
}

