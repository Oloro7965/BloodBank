using BloodBank.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.DeleteDonorCommand
{
    public class DeleteDonorCommand:IRequest<ResultViewModel>
    {
        public DeleteDonorCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
