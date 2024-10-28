using BloodBank.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Entities
{
    public class Stock:BaseEntity
    {
        public Stock(decimal quantity, EBloodType bloodType, ERhFactor rhFactor)
        {
            Quantity = quantity;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public decimal Quantity { get;private set; }
        public EBloodType BloodType { get; private set; }
        public ERhFactor RhFactor { get; private set; }
    }
}
