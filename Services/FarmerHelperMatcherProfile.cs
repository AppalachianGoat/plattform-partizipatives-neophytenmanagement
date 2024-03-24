using AutoMapper;
using plattform_partizipatives_neophytenmanagement.Models;

namespace plattform_partizipatives_neophytenmanagement.Services
{
    public class FarmerHelperMatcherProfile : Profile
    {
        public FarmerHelperMatcherProfile()
        {
            CreateMap<CreateFarmerHelpRequestDto, FarmerHelpRequest>();
        }
    }
}