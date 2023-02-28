using System.ComponentModel.DataAnnotations;

namespace GrupoColorado.Application.Models;

public record RegisterCustomerModel
{
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

    [Required(ErrorMessage = "Campo {0} é obrigatório.")]
    public AddressModel Address { get; init; }
}