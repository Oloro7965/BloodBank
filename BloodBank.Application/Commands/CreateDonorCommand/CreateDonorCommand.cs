using BloodBank.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.CreateDonorCommand
{
    public class CreateDonorCommand:IRequest<Guid>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public EBloodType BloodType { get; set; }
        public ERhFactor RhFactor { get; set; }
    }
}
