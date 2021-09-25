using AutoMapper;
using Paychecks.Api.Models.Employee;
using Paychecks.Domain.Entities;

namespace Paychecks.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
        }
    }
}