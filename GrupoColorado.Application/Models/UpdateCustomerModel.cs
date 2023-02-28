using System.ComponentModel.DataAnnotations;
using GrupoColorado.Domain.ValueObjects;

namespace GrupoColorado.Application.Models;

public record UpdateCustomerModel
{
    [Required(ErrorMessage = "Campo {0} é obrigatório.")]
    public long Id { get; init; }

    [Required(ErrorMessage = "Campo {0} é obrigatório.")]
    [MinLength(2)]
    [MaxLength(100)]
    public string Name { get; init; }

    [Required(ErrorMessage = "Campo {0} é obrigatório.")]
    [MinLength(2)]
    [MaxLength(100)]
    public string City { get; init; }

    [Required(ErrorMessage = "Campo {0} é obrigatório.")]
    [MinLength(2)]
    [MaxLength(2)]
    public string State { get; init; }

    public AddressModel Address { get; init; }
}