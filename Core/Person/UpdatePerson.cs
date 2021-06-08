using Core.Person.Interfaces;
using Core.Person.Validators;
using Core.Infrastructure.Exceptions;
using DataAccess.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace Core.Person
{
    public class UpdatePerson : IUpdatePerson
    {
        IPersonRepository _personRepository;
        private readonly PersonValidator _personValidator;

        public UpdatePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _personValidator = PersonValidator.Validate().UpdatePersonValidator();
        }

        public async Task<bool> Execute(Model.Person person)
        {
            var personValidated = _personValidator.Validate(person);

            if (!personValidated.IsValid)
            {
                throw new ApiDomainException(personValidated.Errors);
            }

            return await _personRepository.UpdateAsync(person);
        }
    }
}
