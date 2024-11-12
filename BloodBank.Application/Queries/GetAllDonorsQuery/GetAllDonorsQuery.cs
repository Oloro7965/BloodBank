using BloodBank.Application.ViewModels;
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
    }
}
