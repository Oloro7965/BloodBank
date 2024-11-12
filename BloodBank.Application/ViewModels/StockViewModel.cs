using BloodBank.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.ViewModels
{
    public class StockViewModel
    {
        public StockViewModel(decimal quantityML, EBloodType bloodType, ERhFactor rhFactor)
        {
            QuantityML = quantityML;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public decimal QuantityML { get; private set; }
        public EBloodType BloodType { get; private set; }
        public ERhFactor RhFactor { get; private set; }
    }
}
