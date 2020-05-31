using AutoMapper;
using CarRentalCo.Administration.Application.Companies.Dtos;
using CarRentalCo.Administration.Domain.Companies;
using System.Linq;
using static CarRentalCo.Administration.Application.Companies.Features.AddCompanyAgency.AddCompanyAgencyCommand;

namespace CarRentalCo.Administration.Application.Companies
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            //domain => dto
            CreateMap<AgencyAdress, AgencyAdressDto>();
            CreateMap<Agency, AgencyDto>()
                .ForMember(x => x.Id, src => src.MapFrom(s => s.Id.Value))
                .ForMember(x => x.Role, src => src.MapFrom(s => (AgencyRoleDto)s.Role))
                .ForMember(x => x.RentalCars, src => src.MapFrom(s => s.RentalCars.Select(z => z.Value)));

            CreateMap<CompanyContact, CompanyContactDto>();
            CreateMap<Company, CompanyDto>()
                .ForMember(x => x.Id, src => src.MapFrom(s => s.Id.Value))
                .ForMember(x => x.OwnerId, src => src.MapFrom(s => s.OwnerId.Value));

            //command => domain
            CreateMap<AddCompanyAgencyAdressModel, AgencyAdress>().ConstructUsing(ctor => AgencyAdress.Create(ctor.Street, ctor.Number,
                ctor.City, ctor.PostalCode, ctor.Country));
        }
    }
}
