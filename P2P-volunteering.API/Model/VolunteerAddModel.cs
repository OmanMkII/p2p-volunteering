namespace P2P_volunteering.API.Controllers
{
    public class VolunteerAddModel
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public AddressModel Address { get; set; }
    }
}
