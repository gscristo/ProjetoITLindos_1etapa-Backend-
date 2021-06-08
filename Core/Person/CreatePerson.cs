using Core.Infrastructure.Exceptions;
using Core.Person.Interfaces;
using DataAccess.Interfaces;
using System.Threading.Tasks;
using Core.Person.Validators;
using System.Linq;

namespace Core.Person
{
    public class CreatePerson : ICreatePerson
    {
        IPersonRepository _personRepository;
        private readonly PersonValidator _personValidator;

        public CreatePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _personValidator = PersonValidator.Validate().CreatePersonValidator();
        }

        public async Task<Model.Person> Execute(Model.Person person)
        {
            var PersonValidated = _personValidator.Validate(person);

            if (!PersonValidated.IsValid)
            {
                throw new ApiDomainException(PersonValidated.Errors);

            }



            var allPerson = await _personRepository.GetAllAsync();

            var found = allPerson.ToList().Find(x => x.SocialNumber == person.SocialNumber);

            if (found != null)
            {
                string bloqueio = "Este CPF já está cadastrado";

                throw new ApiDomainException(bloqueio);
            }

            person.Status = true;

            person.PersonId = await _personRepository.InsertAsync(person);

            return person;
        }
    }
}
