using AutoMapper;
using WebMinimumApi1.Model;

namespace WebMinimumApi1.Properties
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<ToDo, ToDoDTO>();
        }
    }
}
