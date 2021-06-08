using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Person.Interfaces
{
    public interface IGetPersonByCpf
    {
        Task<IEnumerable<Model.Person>> Execute(string SocialNumber);
    }
}