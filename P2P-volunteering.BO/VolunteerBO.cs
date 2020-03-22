using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using P2P_volunteering.DAL.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2P_volunteering.BO
{
    public class VolunteerBO : IVolunteerBO
    {
        private readonly IMainDBContext _context;
        public VolunteerBO(IMainDBContext context)
        {
            _context = context;
        }

        public async Task AddVolunteerAsync(Volunteer volunter)
        {
            _context.Volunteer.Add(volunter);
            await _context.SaveChangesAsync();
        }

        public List<Volunteer> ListVolunteers(double longitude, double latitude, int maxResults)
        {
            var point = new Point(longitude, latitude) { SRID = 4326 }; //TODO move this into the .Geo project ?

            return _context.Volunteer
                .Include(v => v.IdAddressNavigation)
                .OrderBy(v => v.IdAddressNavigation.Coords.Distance(point))
                .Take(maxResults)
                .ToList();
        }
    }
}