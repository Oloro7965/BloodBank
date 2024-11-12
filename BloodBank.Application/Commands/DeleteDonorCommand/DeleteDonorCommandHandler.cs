using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.DeleteDonorCommand
{
    public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand, ResultViewModel>
    {
        private readonly IDonorRepository _donorRepository;

        public DeleteDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.Id);

            if (donor is null)
            {
                return ResultViewModel.Error("Doador não encontrado no sistema");
            }
            donor.Delete();

            await _donorRepository.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
