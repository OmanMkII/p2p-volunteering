using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using P2P_volunteering.BO;
using P2P_volunteering.DAL.Model;
using P2P_volunteering.Geo;

namespace P2P_volunteering.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolunteerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVolunteerBO _volunteerBO;
        private readonly ICoordsService _coordsService;

        public VolunteerController(IMapper mapper, IVolunteerBO volunteerBO, ICoordsService coordsService)
        {
            _mapper = mapper;
            _volunteerBO = volunteerBO;
            _coordsService = coordsService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(VolunteerAddModel model)
        {
            var volunteer = _mapper.Map<Volunteer>(model);
            await _volunteerBO.AddVolunteerAsync(volunteer);

            return Ok();
        }

        [HttpGet]
        public IEnumerable<VolunteerModel> Get([FromQuery]double longitude, [FromQuery]double latitude)
        {
            var volunteers = _volunteerBO.ListVolunteers(longitude, latitude, 5); //TODO move the number of results to the config
            var volunteerModels = volunteers.Select(v => _mapper.Map<VolunteerModel>(v)).ToList();

            foreach (var model in volunteerModels)
            {
                model.Distance = _coordsService.GetDistance(model.Coords as Point, longitude, latitude);
            }

            return volunteerModels;
        }
    }
}