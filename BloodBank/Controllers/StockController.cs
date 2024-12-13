using BloodBank.Application.Commands.CreateDonorCommand;
using BloodBank.Application.Commands.CreateStockCommand;
using BloodBank.Application.Commands.DeleteDonorCommand;
using BloodBank.Application.Commands.UpdateDonorCommand;
using BloodBank.Application.Queries.GetAllDonationsQuery;
using BloodBank.Application.Queries.GetAllDonorsQuery;
using BloodBank.Application.Queries.GetAllStocksQuery;
using BloodBank.Application.Queries.GetDonorQuery;
using BloodBank.Application.Queries.GetStockQuery;
using BloodBank.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/Stock")]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Query = new GetAllStocksQuery();

            var Fields = await _mediator.Send(Query);

            return Ok(Fields);
        }
        [HttpGet("BloodType")]
        public async Task<IActionResult> GetByBloodType([FromQuery] EBloodType bloodtype)
        {
            var Query = new GetStockQuery(bloodtype);

            var Field = await _mediator.Send(Query);

            return Ok(Field);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStock(CreateStockCommand command)
        {
            var DonorId = await _mediator.Send(command);

            return Ok();
        }
    }
}
