namespace plattform_partizipatives_neophytenmanagement.Services
{
    public class CreateInvasiveSpeciesTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public interface IInvasiveSpeciesTypeService
    {

    }
}