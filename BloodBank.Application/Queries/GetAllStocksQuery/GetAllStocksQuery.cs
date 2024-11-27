using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetAllStocksQuery
{
    public class GetAllStocksQuery: IRequest<ResultViewModel<List<StockViewModel>>>
    {
    }
}
