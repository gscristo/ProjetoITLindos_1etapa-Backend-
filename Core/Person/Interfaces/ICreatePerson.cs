using System.Threading.Tasks;

namespace Core.Person.Interfaces
{
    public interface ICreatePerson
    {
        Task<Model.Person> Execute(Model.Person person);
    }
}
