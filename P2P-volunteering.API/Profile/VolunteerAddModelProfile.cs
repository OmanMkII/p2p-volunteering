using AutoMapper;
using P2P_volunteering.DAL.Model;

namespace P2P_volunteering.API.Controllers
{
    public class VolunteerAddModelProfile : Profile
    {
        public VolunteerAddModelProfile()
        {
            CreateMap<VolunteerAddModel, Volunteer>()
                .ForMember(dest => dest.IdAddressNavigation, opt => opt.MapFrom(src => src.Address));
        }
    }
}