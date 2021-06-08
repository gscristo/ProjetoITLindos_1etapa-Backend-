using Core.Person.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Person
{
    public class GetPersonByName : IGetPersonByName
    {

        IPersonRepository _personRepository;

        public GetPersonByName(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Model.Person>> Execute(string Name)
        {

            var result = await _personRepository.GetPersonByNameAsync(Name);

            List<Model.Person> output = new List<Model.Person>();

            foreach (var item in result)
            {
                output.Add(item);
            }

            return output;


        }
    }
}
