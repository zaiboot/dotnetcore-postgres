namespace Prizes.Api.Mapping.Profiles
{
    using AutoMapper;
    using Prizes.Repository.DTO;
    using Prizes.Models;

    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CustomerInformation,Customer>()
            .ForMember( c => c.Name, opt => opt.MapFrom( ci => ci.CustomerName) );
           
        }
    }
}
