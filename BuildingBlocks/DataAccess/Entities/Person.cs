using System;

namespace DataAccess.Entities
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
    }
}
