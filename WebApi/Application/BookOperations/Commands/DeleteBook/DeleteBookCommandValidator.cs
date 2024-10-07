using FluentValidation;
using WebApi.Application.Commands.BookOperations.DeleteBook;

namespace WebApi.Application.Commands.BookOperations.CreateBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            
        }
    }
}