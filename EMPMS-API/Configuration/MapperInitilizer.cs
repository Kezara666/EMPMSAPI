using AutoMapper;
using EMPMS_API.Data.Employee;
using EMPMS_API.Models.Emails;

namespace EMPMS_API.Configuration
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<EmployeeData, EmployeeDTO>().ReverseMap();          
        }
    }
}
