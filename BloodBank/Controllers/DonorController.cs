﻿using BloodBank.Application.Commands.CreateDonorCommand;
using BloodBank.Application.Commands.DeleteDonorCommand;
using BloodBank.Application.Commands.UpdateDonorCommand;
using BloodBank.Application.Queries.GetAllDonorsQuery;
using BloodBank.Application.Queries.GetDonorQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/Donors")]
    public class DonorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Query = new GetAllDonorsQuery();

            var Fields = await _mediator.Send(Query);

            return Ok(Fields);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetDonorById([FromQuery] Guid id)
        {
            var Query = new GetDonorQuery(id);

            var Field = await _mediator.Send(Query);

            return Ok(Field);
        }
        //[HttpGet("{id}")]
        //public IActionResult Get()
        //{
        //    return Ok();
        //}
        [HttpPost]
        public async Task<IActionResult> CreateDonor(CreateDonorCommand command)
        {
            var DonorId = await _mediator.Send(command);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDono(UpdateDonorCommand command)
        {
            //command.Id = id;

            var result = await _mediator.Send(command);


            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(Guid id)
        {
            var command = new DeleteDonorCommand(id);

            var result = await _mediator.Send(command);

            return Ok();

        }
    }
}
