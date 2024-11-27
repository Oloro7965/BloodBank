using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetAllDonationsQuery
{
    public class GetAllDonationsQuery: IRequest<ResultViewModel<List<DonationViewModel>>>
    {
        //public EBloodType? bloodtype { get; set; }

    }
}
