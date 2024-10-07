using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Commands.BookOperations.CreateBook;
using WebApi.Application.Commands.BookOperations.DeleteBook;
using WebApi.Application.Queries.BookOperations.GetBookDetail;
using WebApi.Application.Queries.BookOperations.GetBooks;
using WebApi.Application.Commands.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.Application.Commands.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.Application.Commands.BookOperations.UpdateBook.UpdateBookCommand;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /* private static List<Book> BookList = new List<Book>()
        {
            new Book{
                Id = 1,
                Title = "Lean Startup",
                GenreId = 1, //PersonalGrowth
                PageCount = 200,
                PublishDate = new DateTime(2001,06,12)
            },
            new Book{
                Id = 2,
                Title = "Herland",
                GenreId = 2, //Science Fiction
                PageCount = 250,
                PublishDate = new DateTime(2010,05,23)
            },
            new Book{
                Id = 3,
                Title = "Dune",
                GenreId = 2, //Science Fiction
                PageCount = 540,
                PublishDate = new DateTime(2002,12,21)
            }
        }; */

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) ///localhost:5001/Books/1"
        {
            BookDetailViewModel result;

        
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();

            return Ok(result);

        }

        /* [HttpGet]
        public Book GetById([FromQuery]string id) ///localhost:5001/Books?id=1"
        {
            var book = _context.Books.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        } */


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
           
                command.Model = newBook;

                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);

                /* if (!result.IsValid)
                    foreach (var item in result.Errors)
                    {
                        Console.WriteLine("Ozellik" + item.PropertyName + "error message: " + item.ErrorMessage);
                    }
                else
                    command.Handle(); */

                command.Handle();   

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;

                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

            return Ok();

        }
    }
}