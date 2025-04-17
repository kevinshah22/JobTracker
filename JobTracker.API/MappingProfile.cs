using AutoMapper;
using JobTracker.ViewModel;

namespace JobTracker.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Models.JobApplication, JobApplicationModel>().ReverseMap();
            CreateMap<Data.Models.Company, CompanyModel>().ReverseMap();
            CreateMap<Data.Models.User, UserRegistrationModel>().ReverseMap();
        }
    }
}
