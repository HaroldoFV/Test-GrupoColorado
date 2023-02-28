using FluentValidation;
using GrupoColorado.Domain.ValueObjects;

namespace GrupoColorado.Domain.Validations;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(address => address.Street).NotNull().NotEmpty().Length(2, 100).WithMessage("Informe uma Rua válida.");
        RuleFor(address => address.Number).NotNull().NotEmpty().WithMessage("Informe um número válido.");
        RuleFor(address => address.Neighborhood).NotNull().NotEmpty().Length(2, 100)
            .WithMessage("Informe um bairro válido.");
        RuleFor(address => address.City).NotNull().NotEmpty().Length(2, 100).WithMessage("Informe uma Cidade válida.");
        RuleFor(address => address.State).NotNull().NotEmpty().Length(2, 2).WithMessage("Informe um Estado válido.");
        RuleFor(address => address.Country).NotNull().NotEmpty().WithMessage("Informe um País válido.");
        RuleFor(address => address.ZipCode).NotNull().NotEmpty().Length(9, 9).WithMessage("Informe um CEP válido.");
    }
}