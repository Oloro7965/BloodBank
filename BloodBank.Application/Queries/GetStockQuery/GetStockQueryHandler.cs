using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetStockQuery
{
    public class GetStockQueryHandler : IRequestHandler<GetStockQuery, ResultViewModel<StockViewModel>>
    {
        private readonly IStockRepository _stockRepository;

        public GetStockQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<ResultViewModel<StockViewModel>> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var stock = await _stockRepository.GetByBloodTypeAsync(request.bloodtype);
            //var users = _dbcontext.Users.Where(u => u.IsActive.Equals(true));
            if (stock is null)
            {
                return ResultViewModel<StockViewModel>.Error("Este Estoque não existe");

            }
            var StockDetailViewModel = new StockViewModel(stock.QuantityML,stock.BloodType,stock.RhFactor);
            return ResultViewModel<StockViewModel>.Success(StockDetailViewModel);
        }
    }
}
