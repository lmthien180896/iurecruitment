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
        }
    }
}