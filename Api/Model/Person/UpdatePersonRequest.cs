using System;

namespace Api.Model.Person
{
    public class UpdatePersonRequest
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

        public static implicit operator Core.Person.Model.Person (UpdatePersonRequest updatePersonRequest)
        {
            if (updatePersonRequest == null)
                return null;

            return new Core.Person.Model.Person
            {
                PersonId = updatePersonRequest.PersonId,
                Name = updatePersonRequest.Name,
                Email = updatePersonRequest.Email,
                SocialNumber = updatePersonRequest.SocialNumber,
                Fone = updatePersonRequest.Fone,
                ZipCode = updatePersonRequest.ZipCode,
                Street = updatePersonRequest.Street,
                Number = updatePersonRequest.Number,
                Neighborhood = updatePersonRequest.Neighborhood,
                City = updatePersonRequest.City,
                State = updatePersonRequest.State,
                Status = updatePersonRequest.Status
            };
        }
    }
}
