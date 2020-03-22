using NetTopologySuite.Geometries;
using System.Text.Json.Serialization;

namespace P2P_volunteering.API.Controllers
{
    public class VolunteerModel
    {
        public string Name { get; set; }

        public double Distance { get; set; }

        [JsonIgnore]
        public Geometry Coords { get; set; }
    }
}
