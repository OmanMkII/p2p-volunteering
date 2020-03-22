using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace P2P_volunteering.DAL.Model
{
    public partial class Address
    {
        public Address()
        {
            Volunteer = new HashSet<Volunteer>();
        }

        public int Id { get; set; }
        public string CountryRegion { get; set; }
        public string Locality { get; set; }
        public string AdminDistrict { get; set; }
        public string AdminDistrict2 { get; set; }
        public string Country { get; set; }
        public string HouseNumber { get; set; }
        public string AddressLine { get; set; }
        public string StreetName { get; set; }
        public string FormattedAddress { get; set; }
        public Geometry Coords { get; set; }

        public virtual ICollection<Volunteer> Volunteer { get; set; }
    }
}
