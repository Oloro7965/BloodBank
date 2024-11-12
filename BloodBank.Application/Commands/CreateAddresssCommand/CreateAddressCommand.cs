using BloodBank.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.CreateAddresssCommand
{
    public class CreateAddressCommand:IRequest<Guid>
    {

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get;  set; }
        public string PostalCode { get;  set; }

        
    }
}
