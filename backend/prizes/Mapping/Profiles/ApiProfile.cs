namespace Prizes.Api.Mapping.Profiles
{
    using AutoMapper;
    using Prizes.Models;

    public class ApiProfile : Profile
    {
        public ApiProfile()
        {           
           CreateMap<Prizes.DTO.Prize, Prize>()
            .ForMember( p => p.Description, opt => opt.MapFrom( mp => mp.Name ) );
           ;
        }
    }
}
