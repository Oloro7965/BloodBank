using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.CreateAddresssCommand
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Guid>
    {
        
        public Task<Guid> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //viacep ou api dos correios, brasilApi
        //buscar em serviço externo e salvar no banco e depois mandar pra entidade
    }
}
