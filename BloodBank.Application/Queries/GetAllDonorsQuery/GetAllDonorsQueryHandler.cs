using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetAllDonorsQuery
{
    public class GetAllDonorsQueryHandler : IRequestHandler<GetAllDonorsQuery, ResultViewModel<List<DonorViewModel>>>
    {
        private readonly IDonorRepository _donorRepository;

        public GetAllDonorsQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel<List<DonorViewModel>>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _donorRepository.GetAllAsync(request.bloodtype);
            //var users = _dbcontext.Users.Where(u => u.IsActive.Equals(true));
            var contactViewModel = contacts.Select(b => new DonorViewModel(b.FullName
                 , b.Email, b.Age,b.BirthDate,b.Gender.ToString(),b.Weight,b.BloodType.ToString()
                 ,b.RhFactor.ToString()))
                 .ToList();

            return ResultViewModel<List<DonorViewModel>>.Success(contactViewModel);
        }
    }
}
