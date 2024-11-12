using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetAllStocksQuery
{
    public class GetAllStocksQueryHandler : IRequestHandler<GetAllStocksQuery, ResultViewModel<List<StockViewModel>>>
    {
        private readonly IStockRepository _stockRepository;

        public GetAllStocksQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<ResultViewModel<List<StockViewModel>>> Handle(GetAllStocksQuery request, CancellationToken cancellationToken)
        {
            var stocks = await _stockRepository.GetAllAsync();
            //var users = _dbcontext.Users.Where(u => u.IsActive.Equals(true));
            if (request.bloodtype is null)
            {
                var stockViewModel = stocks.Select(b => new StockViewModel(b.QuantityML
                 , b.BloodType,b.RhFactor))
                 .ToList();
                return ResultViewModel<List<StockViewModel>>.Success(stockViewModel);
            }
            else
            {
                var stockViewModel = stocks.
                Where(d => d.BloodType == request.bloodtype).Select(b => new StockViewModel(b.QuantityML
                 , b.BloodType, b.RhFactor))
                 .ToList();
                return ResultViewModel<List<StockViewModel>>.Success(stockViewModel);
            }
        }
    }
}
