using AutoMapper;
using WebApp.Domain.Entities;
using WebApp.Service.DTOs.Authors;
using WebApp.Service.DTOs.Books;
using WebApp.Service.DTOs.Discounts;
using WebApp.Service.DTOs.Genres;
using WebApp.Service.DTOs.Publishers;

namespace WebApp.Service.Mappers;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Author, AuthorCreationDto>().ReverseMap();
        CreateMap<Author, AuthorResultDto>().ReverseMap();
        CreateMap<Author, AuthorUpdateDto>().ReverseMap();
        CreateMap<AuthorCreationDto, AuthorResultDto>().ReverseMap();

        CreateMap<Book, BookCreationDto>().ReverseMap();
        CreateMap<Book, BookResultDto>().ReverseMap();
        CreateMap<Book, BookUpdateDto>().ReverseMap();
        CreateMap<BookCreationDto, BookResultDto>().ReverseMap();

        CreateMap<Discount, DiscountCreationDto>().ReverseMap();
        CreateMap<Discount, DiscountResultDto>().ReverseMap();
        CreateMap<Discount, DiscountUpdateDto>().ReverseMap();
        CreateMap<DiscountCreationDto, DiscountResultDto>().ReverseMap();

        CreateMap<Genre, GenreCreationDto>().ReverseMap();
        CreateMap<Genre, GenreResultDto>().ReverseMap();
        CreateMap<Genre, GenreUpdateDto>().ReverseMap();
        CreateMap<GenreCreationDto, GenreResultDto>().ReverseMap();

        CreateMap<Publisher, PublisherCreationDto>().ReverseMap();
        CreateMap<Publisher, PublisherResultDto>().ReverseMap();
        CreateMap<Publisher, PublisherUpdateDto>().ReverseMap();
        CreateMap<PublisherCreationDto, PublisherResultDto>().ReverseMap();
    }

}
