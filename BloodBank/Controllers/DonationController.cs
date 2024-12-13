using BloodBank.Application.Commands.CreateDonationCommand;
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

            var Donations = await _mediator.Send(Query);

            return Ok(Donations);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetDonationById([FromQuery] Guid id)
        {
            var Query = new GetDonationQuery(id);

            var Donation = await _mediator.Send(Query);

            return Ok(Donation);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDonation([FromQuery] CreateDonationCommand command)
        {
            var DonationId = await _mediator.Send(command);
            if (!DonationId.IsSuccess)
            {
                return BadRequest(DonationId.Message);
            }
            return Ok(DonationId);
        }
    }
}
