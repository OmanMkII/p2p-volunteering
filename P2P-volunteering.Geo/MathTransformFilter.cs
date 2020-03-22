using GeoAPI.CoordinateSystems.Transformations;
using NetTopologySuite.Geometries;

namespace P2P_volunteering.Geo
{
    internal class MathTransformFilter : ICoordinateSequenceFilter
    {
        readonly IMathTransform _transform;

        public MathTransformFilter(IMathTransform transform)
            => _transform = transform;

        public bool Done => false;
        public bool GeometryChanged => true;

        public void Filter(CoordinateSequence seq, int i)
        {
            var result = _transform.Transform(
                new[]
                {
                    seq.GetOrdinate(i, Ordinate.X),
                    seq.GetOrdinate(i, Ordinate.Y)
                });
            seq.SetOrdinate(i, Ordinate.X, result[0]);
            seq.SetOrdinate(i, Ordinate.Y, result[1]);
        }
    }
}