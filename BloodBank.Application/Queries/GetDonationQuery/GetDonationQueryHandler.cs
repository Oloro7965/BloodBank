using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetDonationQuery
{
    public class GetDonationQueryHandler : IRequestHandler<GetDonationQuery, ResultViewModel<DonationViewModel>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetDonationQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<ResultViewModel<DonationViewModel>> Handle(GetDonationQuery request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepository.GetByIdAsync(request.Id);
            if (donation is null)
            {
                return ResultViewModel<DonationViewModel>.Error("Este contato não existe");
            }

            var DonationDetailViewModel = new DonationViewModel(donation.DonationDate
                 ,donation.QuantityML);

            //var UserDetailViewModel = UserViewModel.FromEntity(user);
            return ResultViewModel<DonationViewModel>.Success(DonationDetailViewModel);
        }
    }
}
