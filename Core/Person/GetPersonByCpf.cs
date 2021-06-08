using Core.Person.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Person
{
    public class GetPersonByCpf : IGetPersonByCpf
    {

        IPersonRepository _personRepository;

        public GetPersonByCpf(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Model.Person>> Execute(string SocialNumber)
        {

            var result = await _personRepository.GetPersonByCpfAsync(SocialNumber);

            List<Model.Person> output = new List<Model.Person>();

            foreach (var item in result)
            {
                output.Add(item);
            }

            return output;


        }
    }
}