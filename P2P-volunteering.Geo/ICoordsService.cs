using NetTopologySuite.Geometries;

namespace P2P_volunteering.Geo
{
    public interface ICoordsService
    {
        /// <summary>
        /// Returns the distance between two points in meters
        /// </summary>
        /// <param name="coords1"></param>
        /// <param name="coords2"></param>
        /// <returns></returns>  double GetDistance(Point coords1, Point coords2);
        double GetDistance(Point coords1, Point coords2);

        /// <summary>
        /// Returns the distance between two points in meters.
        /// </summary>
        /// <param name="coords1">First set of coordinates. The SRID should be 4326.</param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        double GetDistance(Point coords1, double longitude, double latitude);

        /// <summary>
        /// Creates a point object
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        Point CreatePoint(double longitude, double latitude);
    }
}