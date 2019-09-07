namespace AppManager.Api.Mapping.Profiles
{
    using AutoMapper;
    using AppManager.Repository.DTO;
    using AppManager.Models;

    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CustomerInformation,Customer>()
            .ForMember( c => c.Name, opt => opt.MapFrom( ci => ci.CustomerName) );
        }
    }
}
