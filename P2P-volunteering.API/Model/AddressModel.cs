namespace P2P_volunteering.API.Controllers
{
    public class AddressModel
    {
        public string CountryRegion { get; set; }
        public string Locality { get; set; }
        public string AdminDistrict { get; set; }
        public string AdminDistrict2 { get; set; }
        public string Country { get; set; }
        public string HouseNumber { get; set; }
        public string AddressLine { get; set; }
        public string StreetName { get; set; }
        public string FormattedAddress { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
