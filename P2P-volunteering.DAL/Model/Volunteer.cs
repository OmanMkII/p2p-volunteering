namespace P2P_volunteering.DAL.Model
{
    public partial class Volunteer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int IdAddress { get; set; }

        public virtual Address IdAddressNavigation { get; set; }
    }
}
