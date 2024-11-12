using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetAllDonationsQuery
{
    public class GetAllDonationsQueryHandler : IRequestHandler<GetAllDonationsQuery, ResultViewModel<List<DonationViewModel>>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetAllDonationsQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<ResultViewModel<List<DonationViewModel>>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepository.GetAllAsync();
            //var users = _dbcontext.Users.Where(u => u.IsActive.Equals(true));
            if (request.bloodtype is null)
            {
                var donationViewModel = donations.Select(b => new DonationViewModel(b.DonationDate
                 , b.QuantityML))
                 .ToList();
                return ResultViewModel<List<DonationViewModel>>.Success(donationViewModel);
            }
            else
            {
                var donationViewModel = donations.
                Where(d => d.Donor.BloodType == request.bloodtype).Select(b => new DonationViewModel(b.DonationDate
                 , b.QuantityML))
                 .ToList();
                return ResultViewModel<List<DonationViewModel>>.Success(donationViewModel);
            }
        }
    }
}
