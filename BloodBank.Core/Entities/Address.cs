using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Entities
{
    public class Address:BaseEntity
    {
        public Address(string street, string city, string state, string postalCode)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public string Street { get; private set; }
        public string City { get;private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }

        public Donor Donor { get; private set; }
    }
}
