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
            QuantityML = quantity;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }
        private Stock() { }
        public decimal QuantityML { get;private set; }
        public EBloodType BloodType { get; private set; }
        public ERhFactor RhFactor { get; private set; }
        //verificar se o tipo de sangue existe
        //bloodtype e/ou rhfactor
    }
}
