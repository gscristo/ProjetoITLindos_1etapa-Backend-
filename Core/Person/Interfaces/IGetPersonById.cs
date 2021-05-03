using System;
using System.Threading.Tasks;

namespace Core.Person.Interfaces
{
    public interface IGetPersonById
    {
        Task<Model.Person> Execute(Guid personId);
    }
}
