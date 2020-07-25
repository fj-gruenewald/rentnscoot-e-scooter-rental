using System;
using System.Collections.Generic;
using System.Text;

namespace RentNScoot.Domain
{
    public class Customer : IEntity
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public string Iban { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string StreetNR { get; set; } = string.Empty;
        public string Plz { get; set; } = string.Empty;

        //
        public Customer()
        { }

        //
        public Customer(string name,string familyname, string email, string iban, string city, string street, string streetNr, string plz)
        {
            Name = name;
            FamilyName = familyname;
            EMail = email;
            Iban = iban;
            City = city;
            Street = street;
            StreetNR = streetNr;
            Plz = plz;
        }

        //
        public Customer(string id, string name, string familyname, string email, string iban, string city, string street, string streetNr, string plz)
        {
            Id = id;
            Name = name;
            FamilyName = familyname;
            EMail = email;
            Iban = iban;
            City = city;
            Street = street;
            StreetNR = streetNr;
            Plz = plz;
        }
    }
}
