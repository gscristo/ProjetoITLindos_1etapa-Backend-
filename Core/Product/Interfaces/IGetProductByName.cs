using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Product.Interfaces
{
    public interface IGetProductByName
    {
        Task<IEnumerable<Model.Product>> Execute(string Name);
    }
}
