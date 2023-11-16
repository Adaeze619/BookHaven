using AutoMapper;
using BookHaven.Domain.Model;
using BookHaven.Domain.RequestDTO;

namespace BookHaven.Common.Automapper
{
    public class BookHavenAutomapper : Profile
    {
        public BookHavenAutomapper()
        {
           // CreateMap<BookRequestDTO, Book>()
           // .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.BookHavenTag.Split(',').Select(x => new BookHavenTag() { Name = x.Trim() })));
        }
    }
}
