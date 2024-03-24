namespace plattform_partizipatives_neophytenmanagement.Services
{

    public class CreateFarmerHelpRequestDto
    {
        public int OwnerId { get; set; }
        public string Location { get; set; }
        public int WorkVolume { get; set; }
        public int NumberOfHelpers { get; set; }
        public List<int> InvasiveSpeciesTypeIds { get; set; }
    }

    public class FarmerHelpRequestFilterDto
    {
        public string Location { get; set; }
        public double DistanceFromLocation { get; set; }
        public int WorkVolume { get; set; }
        public int NumberOfHelpers { get; set; }
    }



    public interface IFarmerHelpRequestService
    {

    }
}