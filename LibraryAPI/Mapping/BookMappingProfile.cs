using Application.DTO;
using AutoMapper;
using Domain.Entity;

namespace LibraryAPI.Mapping
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookCreateDTO, Book>()
                .ForMember(destination => destination.BookAuthors, opt => opt.NullSubstitute(new List<BookAuthor>())));

            CreateMap<Book, BookCreateDTO>()
                .ForMember(dest => dest.Authors,
                    opt => opt.MapFrom(src => src.BookAuthors.Select(ur => ur.AuthorId).ToList()))
                .ReverseMap();
            CreateMap<Book, BookTakenDTO>()
                .ForMember(dest => dest.Authors,
                    opt => opt.MapFrom(src => src.BookAuthors.Select(ur => ur.Author).ToList()))
                .ReverseMap();
        }
    }
}
