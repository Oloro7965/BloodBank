using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.CreateDonorCommand
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, Guid>
    {
        private readonly IDonorRepository _donorRepository;

        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<Guid> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var Donor = new Donor(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight,request.BloodType,request.RhFactor);

            await _donorRepository.AddAsync(Donor);

            return Donor.Id;
        }
    }
}
