namespace Customers.Api.Mapping.Profiles
{
    using AutoMapper;
    using Customers.Repository.DTO;
    using Customers.Models;

    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CustomerInformation,Customer>()
            .ForMember( c => c.Name, opt => opt.MapFrom( ci => ci.CustomerName) );
        }
    }
}
