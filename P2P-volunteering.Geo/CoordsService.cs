using NetTopologySuite.Geometries;

namespace P2P_volunteering.Geo
{
    public class CoordsService : ICoordsService
    {
        public Point CreatePoint(double longitude, double latitude)
        {
            return new Point(longitude, latitude) { SRID = 4326 };
        }

        public double GetDistance(Point coords1, Point coords2)
        {
            return coords1.ProjectTo(2855).Distance(coords2.ProjectTo(2855));
        }

        public double GetDistance(Point coords1, double longitude, double latitude)
        {
            return GetDistance(coords1, CreatePoint(longitude, latitude));
        }
    }
}