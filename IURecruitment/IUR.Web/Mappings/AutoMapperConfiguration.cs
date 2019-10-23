using AutoMapper;
using IUR.Model.Models;
using IUR.Web.Models;

namespace IUR.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Department, DepartmentViewModel>();                          
            Mapper.CreateMap<Job, JobViewModel>();                          
            Mapper.CreateMap<ApplicantDetail, ApplicantDetailViewModel>();                          
            Mapper.CreateMap<ApplicantDetail, ApplicationViewModel>();                          
            Mapper.CreateMap<User, UserViewModel>();                          
            Mapper.CreateMap<Footer, FooterViewModel>();                          
        }
    }
}