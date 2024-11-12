using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetStockQuery
{
    public class GetStockQuery: IRequest<ResultViewModel<StockViewModel>>
    {
        public GetStockQuery(EBloodType Bloodtype)
        {
            bloodtype = Bloodtype;
        }

        public EBloodType bloodtype { get; set; }
    }
}
