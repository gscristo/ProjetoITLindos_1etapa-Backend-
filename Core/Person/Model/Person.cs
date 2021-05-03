using System;

namespace Core.Person.Model
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SocialNumber { get; set; }
        public string Fone { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool Status { get; set; }

        public static implicit operator Person (DataAccess.Entities.Person model)
        {
            if (model == null)
                return null;

            return new Person
            {
                PersonId = model.PersonId,
                Name = model.Name,
                Email = model.Email,
                SocialNumber = model.SocialNumber,
                Fone = model.Fone,
                ZipCode = model.ZipCode,
                Street = model.Street,
                Number = model.Number,
                Neighborhood = model.Neighborhood,
                City = model.City,
                State = model.State,
                Status = model.Status
            };
        }

        public static implicit operator DataAccess.Entities.Person (Person person)
        {
            if (person == null)
                return null;

            return new DataAccess.Entities.Person
            {
                PersonId = person.PersonId,
                Name = person.Name,
                Email = person.Email,
                SocialNumber = person.SocialNumber,
                Fone = person.Fone,
                ZipCode = person.ZipCode,
                Street = person.Street,
                Number = person.Number,
                Neighborhood = person.Neighborhood,
                City = person.City,
                State = person.State,
                Status = person.Status
            };
        }
    }
}
