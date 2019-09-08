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
            CreateMap<CreateCustomerRequest, CustomerInformation>()
                .ForMember( ci => ci.CustomerName , opt => opt.MapFrom( ccr => ccr.CustomerName ))
                .ForMember( ci => ci.ClaimedAmount ,  opt => opt.Ignore())
                .ForMember( ci => ci.Id , opt => opt.Ignore())
            
            ;
        }
    }
}
