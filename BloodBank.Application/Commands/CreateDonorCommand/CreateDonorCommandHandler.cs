using BloodBank.Application.Validators;
using BloodBank.Application.ViewModels;
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
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, ResultViewModel<Guid>>
    {
        private readonly IDonorRepository _donorRepository;

        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            //fazer if buscando email para checar
            var validator = new CreateDonorValidator();
            var validationResult=validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                .Select(error => new ValidationError
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                })
            .ToList();
                return ResultViewModel<Guid>.Error($"{errors}");
            }
            var Donor = new Donor(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight,request.BloodType,request.RhFactor);

            await _donorRepository.AddAsync(Donor);

            return ResultViewModel<Guid>.Success(Donor.Id);
        }
    }
}
