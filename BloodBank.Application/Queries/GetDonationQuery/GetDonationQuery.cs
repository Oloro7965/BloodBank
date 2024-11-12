using BloodBank.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetDonationQuery
{
    public class GetDonationQuery: IRequest<ResultViewModel<DonationViewModel>>
    {
        public GetDonationQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
