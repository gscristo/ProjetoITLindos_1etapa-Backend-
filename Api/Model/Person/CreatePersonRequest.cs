namespace Api.Model.Person
{
    public class CreatePersonRequest
    {
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

        public static implicit operator Core.Person.Model.Person (CreatePersonRequest createPersonRequest)
        {
            if (createPersonRequest == null)
                return null;

            return new Core.Person.Model.Person
            {
                Name = createPersonRequest.Name,
                Email = createPersonRequest.Email,
                SocialNumber = createPersonRequest.SocialNumber,
                Fone = createPersonRequest.Fone,
                ZipCode = createPersonRequest.ZipCode,
                Street = createPersonRequest.Street,
                Number = createPersonRequest.Number,
                Neighborhood = createPersonRequest.Neighborhood,
                City = createPersonRequest.City,
                State = createPersonRequest.State,
            };
        }
    }
}
