using AutoMapper;
using P2P_volunteering.DAL.Model;

namespace P2P_volunteering.API.Controllers
{
    public class VolunteerModelProfile : Profile
    {
        public VolunteerModelProfile()
        {
            CreateMap<Volunteer, VolunteerModel>()
                .ForMember(dest => dest.Coords, opt => opt.MapFrom(src => src.IdAddressNavigation.Coords));
        }
    }
}