using BloodBank.Application.Commands.CreateDonorCommand;
using BloodBank.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Validators
{
    public class CreateDonorValidator : AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorValidator()
        {
            RuleFor(x => x.Weight)
                .GreaterThanOrEqualTo(50).WithMessage("Doador precisa ter pelo menos 50kg");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("Gênero inválido");
            RuleFor(x => x.BloodType).IsInEnum().WithMessage("tipo sanguíneo inválido");
            RuleFor(x => x.RhFactor).IsInEnum().WithMessage("Fator inválido");
            //RuleFor(x=>x.EailAddress().WithMessage("Email inválido").MustAsync
            //RuleFor(x=>x.Email).Must(PersonMail)
        }
    }
}
