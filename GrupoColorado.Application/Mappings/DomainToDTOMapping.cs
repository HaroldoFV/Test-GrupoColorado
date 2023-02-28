using AutoMapper;
using GrupoColorado.Application.Models;
using GrupoColorado.Domain.Entities;
using GrupoColorado.Domain.ValueObjects;

namespace GrupoColorado.Application.Mappings;

public class DomainToDTOMapping : Profile
{
    public DomainToDTOMapping()
    {
        CreateMap<Customer, GetCustomerModel>(MemberList.None)
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            // .ForMember(x => x.Address, y => y.MapFrom(z => z.Address))
            .ForMember(x => x.City, y => y.MapFrom(z => z.City))
            .ForMember(x => x.State, y => y.MapFrom(z => z.State))
            .ForMember(x => x.DateInsert, y => y.MapFrom(z => z.DateInsert))
            .ForMember(x => x.Address, y => y.MapFrom(z => z.Address));

        CreateMap<Address, AddressModel>(MemberList.None)
            .ForMember(x => x.Street, y => y.MapFrom(z => z.Street))
            .ForMember(x => x.Number, y => y.MapFrom(z => z.Number))
            .ForMember(x => x.Neighborhood, y => y.MapFrom(z => z.Neighborhood))
            .ForMember(x => x.City, y => y.MapFrom(z => z.City))
            .ForMember(x => x.State, y => y.MapFrom(z => z.State))
            .ForMember(x => x.Country, y => y.MapFrom(z => z.Country))
            .ForMember(x => x.ZipCode, y => y.MapFrom(z => z.ZipCode));
    }
}