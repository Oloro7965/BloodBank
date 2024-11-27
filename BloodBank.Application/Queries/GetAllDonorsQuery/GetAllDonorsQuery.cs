using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetAllDonorsQuery
{
    public class GetAllDonorsQuery:IRequest<ResultViewModel<List<DonorViewModel>>>
    {
        public GetAllDonorsQuery(EBloodType? bloodtype)
        {
            this.bloodtype = bloodtype;
        }

        public EBloodType? bloodtype { get; set; }
    }
}
