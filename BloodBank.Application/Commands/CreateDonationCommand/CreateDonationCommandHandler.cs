using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.CreateDonationCommand
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, Guid>
    {
        private readonly IDonationRepository _donationRepository;

        public CreateDonationCommandHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<Guid> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = new Donation(request.DonorId,request.QuantityML);

            await _donationRepository.AddAsync(donation);

            return donation.Id;
        }
    }
}
