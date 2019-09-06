namespace Prizes.Api.Mapping.Profiles
{
    using AutoMapper;
    using prizes.Repository.DTO;
    using Prizes.Models;

    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CustomerInformation,Customer>();
           
        }
    }
}
