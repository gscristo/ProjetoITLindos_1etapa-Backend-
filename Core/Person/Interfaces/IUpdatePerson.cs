using System.Threading.Tasks;

namespace Core.Person.Interfaces
{
   public interface IUpdatePerson
    {
        Task<bool> Execute(Model.Person person);
    }
}
