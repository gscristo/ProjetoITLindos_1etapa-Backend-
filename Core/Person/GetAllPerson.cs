using Core.Person.Interfaces;
using Core.Model;
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Person
{
    public class GetAllPerson : IGetAllPerson
    {
        IPersonRepository _personRepository;

        public GetAllPerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PaginationResponse<Model.Person>> Execute(int pageSize = 20, int pageIndex = 1, string sort = "", string direction = "")
        {
            List<Model.Person> resultList = new List<Model.Person>();

            var result = await _personRepository.GetAllAsyncPagination(pageSize, pageIndex, sort, direction);

            foreach (var item in result.DataList)
            {
                resultList.Add(item);
            }

            return new PaginationResponse<Model.Person>()
            {
                PageIndex = result.PageIndex,
                PageSize = result.PageSize,
                TotalRecords = result.TotalRecords,
                ResultList = resultList
            };
        }
    }
}
