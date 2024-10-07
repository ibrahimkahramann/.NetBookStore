using AutoMapper;
using WebApi.Application.GenreOperations.Queries.GetGenreDetailQuery;
using WebApi.Application.GenreOperations.Queries.GetGenresQuery;
using WebApi.Application.Queries.BookOperations.GetBookDetail;
using WebApi.Application.Queries.BookOperations.GetBooks;
using WebApi.Entities;
using static WebApi.Application.Commands.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.Application.Commands.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace WebApi.Common
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<CreateUserModel, User>();

        }
    }
}