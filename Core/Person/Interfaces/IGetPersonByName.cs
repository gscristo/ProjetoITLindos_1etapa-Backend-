using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Person.Interfaces
{
    public interface IGetPersonByName
    {
        Task<IEnumerable<Model.Person>> Execute(string Name);
    }
}