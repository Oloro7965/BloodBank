using BloodBank.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetDonorQuery
{
    public class GetDonorQuery: IRequest<ResultViewModel<DonorViewModel>>
    {
        public GetDonorQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
