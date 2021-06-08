using System;

namespace Core.Product.Interfaces
{
    public interface IDeleteProductByCode
    {
        public void Execute(string Code);
    }
}