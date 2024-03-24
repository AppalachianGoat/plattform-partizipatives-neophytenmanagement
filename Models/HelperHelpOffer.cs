namespace plattform_partizipatives_neophytenmanagement.Models
{
    public class HelperHelpOffer
    {
        public int Id { get; set; }

        public User OwnerUser { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Location Location { get; set; }

        public double DistanceFromLocation { get; set; }

        public int WorkVolume { get; set; }

        public int NumberOfHelpers { get; set; }
    }
}