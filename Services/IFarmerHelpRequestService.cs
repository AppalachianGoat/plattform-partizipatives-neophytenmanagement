namespace plattform_partizipatives_neophytenmanagement.Services
{

    public class CreateFarmerHelpRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OwnerUserId { get; set; }
        public LocationDto Location { get; set; }
        public int WorkVolume { get; set; }
        public int NumberOfHelpers { get; set; }
        public List<int> InvasiveSpeciesTypeIds { get; set; }
    }

    public class FilterFarmerHelpRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public double DistanceFromLocation { get; set; }
        public int WorkVolume { get; set; }
        public int NumberOfHelpers { get; set; }
    }



    public interface IFarmerHelpRequestService
    {

    }
}