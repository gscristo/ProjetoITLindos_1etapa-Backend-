using Core.Model;
using System.Threading.Tasks;

namespace Core.Person.Interfaces
{
    public interface IGetAllPerson
    {
        Task<PaginationResponse<Model.Person>> Execute(int pageSize = 20, int pageIndex = 1, string sort = "", string direction = "");
    }
}
