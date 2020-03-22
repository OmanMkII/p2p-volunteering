using NetTopologySuite.Geometries;
using P2P_volunteering.DAL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P2P_volunteering.BO
{
    public interface IVolunteerBO
    {
        Task AddVolunteerAsync(Volunteer volunter);
        List<Volunteer> ListVolunteers(double longitude, double latitude, int maxResults);
    }
}