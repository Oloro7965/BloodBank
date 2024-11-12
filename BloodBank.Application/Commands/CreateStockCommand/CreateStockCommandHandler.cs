using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.CreateStockCommand
{
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, Guid>
    {
        private readonly IStockRepository _stockRepository;

        public CreateStockCommandHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<Guid> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            var Stock = new Stock(request.QuantityML, request.BloodType, request.RhFactor);

            await _stockRepository.AddAsync(Stock);

            return Stock.Id;
        }
    }
}
