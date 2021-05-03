using Core.Infrastructure.Exceptions;
using Core.Person.Interfaces;
using DataAccess.Interfaces;
using System;

namespace Core.Person
{
    public class DeletePerson : IDeletePerson
    {
        IPersonRepository _personRepository;

        public DeletePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async void Execute(Guid personId)
        {
            var result = await _personRepository.GetByIdAsync(personId);

            if (result == null)
            {
                throw new ApiDomainException("Person not found");
            }

            await _personRepository.DeleteAsync(result);
        }
    }
}
