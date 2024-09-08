using AutoMapper;
using Domain.Entity;
using Application.DTO;

namespace LibraryAPI.Mapping
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
        }
    }
}
