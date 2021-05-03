using Core.Person.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Threading.Tasks;

namespace Core.Person
{
    public class GetPersonById : IGetPersonById
    {

        IPersonRepository _personRepository;

        public GetPersonById(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Model.Person> Execute(Guid personId)
        {
            return await _personRepository.GetByIdAsync(personId);
        }
    }
}
