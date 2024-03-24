using AutoMapper;
using plattform_partizipatives_neophytenmanagement.Models;

namespace plattform_partizipatives_neophytenmanagement.Services
{
    public class FarmerHelperMatcherProfile : Profile
    {
        public FarmerHelperMatcherProfile()
        {
            CreateMap<CreateFarmerHelpRequestDto, FarmerHelpRequest>();
            CreateMap<CreateHelperHelpOfferDto, HelperHelpOffer>();

            CreateMap<LocationDto, Location>();
            CreateMap<Location, LocationDto>();

            CreateMap<CreateUserDto, User>();

            CreateMap<CreateInvasiveSpeciesTypeDto, InvasiveSpeciesType>();

        }
    }
}