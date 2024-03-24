using plattform_partizipatives_neophytenmanagement.Models;

namespace plattform_partizipatives_neophytenmanagement.Services
{

    public class CreateHelperHelpOfferDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OwnerUserId { get; set; }

        public LocationDto Location { get; set; }

        public double DistanceFromLocation { get; set; }

        public int WorkVolume { get; set; }

        public int NumberOfHelpers { get; set; }
    }

    public class FilterHelperHelpOfferDto
    {
        public int WorkVolume { get; set; }
        public int NumberOfHelpers { get; set; }
    }

    public class HelperHelpOfferService
    {

    }
}