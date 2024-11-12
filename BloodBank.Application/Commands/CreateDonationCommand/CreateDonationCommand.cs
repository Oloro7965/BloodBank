using BloodBank.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.CreateDonationCommand
{
    public class CreateDonationCommand:IRequest<Guid>
    {
        
        public Guid DonorId { get; set; }
        public int QuantityML { get; set; }
    }
}
