using BloodBank.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.CreateStockCommand
{
    public class CreateStockCommand:IRequest<Guid>
    {
        

        public decimal QuantityML { get; set; }
        public EBloodType BloodType { get; set; }
        public ERhFactor RhFactor { get; set; }
    }
}
