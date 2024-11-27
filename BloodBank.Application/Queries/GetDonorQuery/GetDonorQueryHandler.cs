using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetDonorQuery
{
    public class GetDonorQueryHandler : IRequestHandler<GetDonorQuery, ResultViewModel<DonorViewModel>>
    {
        private readonly IDonorRepository _donorRepository;

        public GetDonorQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel<DonorViewModel>> Handle(GetDonorQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.Id);
            if (donor is null)
            {
                return ResultViewModel<DonorViewModel>.Error("Doador não encontrado");
            }

            var DonorDetailViewModel = new DonorViewModel(donor.FullName
                 ,donor.Email, donor.Age, donor.BirthDate, donor.Gender.ToString(), 
                 donor.Weight, donor.BloodType.ToString(), donor.RhFactor.ToString());

            //var UserDetailViewModel = UserViewModel.FromEntity(user);
            return ResultViewModel<DonorViewModel>.Success(DonorDetailViewModel);
        }
    }
}
