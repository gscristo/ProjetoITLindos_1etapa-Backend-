using System;

namespace Core.Person.Interfaces
{
    public interface IDeletePerson
    {
        void Execute(Guid personId);
    }
}
