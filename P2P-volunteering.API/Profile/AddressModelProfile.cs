using AutoMapper;
using NetTopologySuite.Geometries;
using P2P_volunteering.DAL.Model;

namespace P2P_volunteering.API.Controllers
{
    public class AddressModelProfile : Profile
    {
        public AddressModelProfile()
        {
            CreateMap<AddressModel, Address>()
                .ForMember(dest => dest.Coords, opt => opt.MapFrom(src => new Point(src.Longitude, src.Latitude) { SRID = 4326 })); //TODO wire up the mapping to the ICoordsService in .Geo

            CreateMap<Address, AddressModel>()
               .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => (src.Coords as Point).X))
               .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => (src.Coords as Point).Y));

        }
    }
}