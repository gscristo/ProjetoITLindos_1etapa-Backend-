using System;

namespace Core.Product.Interfaces
{
    public interface IDeleteProduct
    {
        void Execute(Guid productId);
    }
}
