using FluentValidation;
using GrupoColorado.Domain.Entities;

namespace GrupoColorado.Domain.Validations;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Name).NotNull().NotEmpty().Length(2, 100).WithMessage("Informe um nome válido.");;
        RuleFor(customer => customer.City).NotNull().NotEmpty().Length(2, 100).WithMessage("Informe uma Cidade válida.");
        RuleFor(customer => customer.State).NotNull().NotEmpty().Length(2, 2).WithMessage("Informe um Estado válido.");

        // Validate the address (its a complex property)
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
    }
}