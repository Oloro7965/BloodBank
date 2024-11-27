using BloodBank.Application.ViewModels;
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
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, ResultViewModel<Guid>>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;

        public CreateDonationCommandHandler(IDonationRepository donationRepository, IDonorRepository donorRepository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.DonorId);
            if (donor.Age<18)
            {
                return ResultViewModel<Guid>.Error("Doador com menos de 18 anos não pode realizar doação");
                
                //Objeto próprio de result
            }
            var donation = new Donation(request.DonorId,request.QuantityML);

            await _donationRepository.AddAsync(donation);

            return ResultViewModel<Guid>.Success(donation.Id);
        }
    }
}
