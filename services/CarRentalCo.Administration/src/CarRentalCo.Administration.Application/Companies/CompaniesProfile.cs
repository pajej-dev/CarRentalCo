using AutoMapper;
using CarRentalCo.Administration.Application.Companies.Dtos;
using CarRentalCo.Administration.Domain.Companies;
using System.Linq;

namespace CarRentalCo.Administration.Application.Companies
{
    public class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            CreateMap<AgencyAdress, AgencyAdressDto>();
            CreateMap<Agency, AgencyDto>()
                .ForMember(x => x.Id, src => src.MapFrom(s => s.Id.Value))
                .ForMember(x => x.Role, src => src.MapFrom(s => (AgencyRoleDto)s.Role))
                .ForMember(x => x.RentalCars, src => src.MapFrom(s => s.RentalCars.Select(z => z.Value)));

            CreateMap<CompanyContact, CompanyContactDto>();
            CreateMap<Company, CompanyDto>()
                .ForMember(x => x.Id, src => src.MapFrom(s => s.Id.Value))
                .ForMember(x => x.OwnerId, src => src.MapFrom(s => s.OwnerId.Value));
                
        }
    }
}
