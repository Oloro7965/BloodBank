using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Entities
{
    public class Donation:BaseEntity
    {
        public Donation(Guid donorId, DateTime donationDate, int quantityML)
        {
            DonorId = donorId;
            DonationDate = donationDate;
            QuantityML = quantityML;
        }

        public Guid DonorId { get;private set; }
        public Donor Donor { get;private set; }
        public DateTime DonationDate { get; private set; }
        public int QuantityML { get; private set; }
    }
}
