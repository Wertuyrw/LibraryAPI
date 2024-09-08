using Application.DTO;
using AutoMapper;
using Domain.Entity;

namespace LibraryAPI.Mapping
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, AuthorCreateDTO>()
                .ReverseMap();
            CreateMap<Author, AuthorTakenDTO>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BooksId, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Book.Id)))
                .ReverseMap();
        }
    }
}
