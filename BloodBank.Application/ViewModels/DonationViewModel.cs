using BloodBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.ViewModels
{
    public class DonationViewModel
    {
        public DonationViewModel(DateTime donationDate, int quantityML)
        {
            DonationDate = donationDate;
            QuantityML = quantityML;
        }

        public DateTime DonationDate { get; private set; }
        public int QuantityML { get; private set; }
    }
}
