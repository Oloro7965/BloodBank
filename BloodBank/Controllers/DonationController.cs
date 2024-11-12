using BloodBank.Application.Queries.GetAllDonationsQuery;
using BloodBank.Application.Queries.GetAllDonorsQuery;
using BloodBank.Application.Queries.GetDonationQuery;
using BloodBank.Application.Queries.GetDonorQuery;
using BloodBank.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/Donations")]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] EBloodType? bloodType)
        {
            var Query = new GetAllDonationsQuery();

            var Fields = await _mediator.Send(Query);

            return Ok(Fields);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetDonationById([FromQuery] Guid id)
        {
            var Query = new GetDonationQuery(id);

            var Field = await _mediator.Send(Query);

            return Ok(Field);
        }
    }
}
