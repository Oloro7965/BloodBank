using BloodBank.Application.Commands.CreateDonationCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Validators
{
    public class CreateDonationValidator:AbstractValidator<CreateDonationCommand>
    {
        public CreateDonationValidator() {
            RuleFor(x => x.QuantityML).GreaterThanOrEqualTo(420)
                .WithMessage("Quantidade de sangue deve ser maior ou igual a 420ml")
                .LessThanOrEqualTo(470).WithMessage("Quantidade de sangue deve ser menor ou igual a 470ml");
        }
    }
}
