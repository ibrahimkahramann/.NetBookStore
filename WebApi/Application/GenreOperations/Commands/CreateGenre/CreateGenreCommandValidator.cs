using FluentValidation;
using WebApi.Application.GenreOperations.Commands.CreateGenre;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(query => query.Model.Name).NotEmpty().MinimumLength(4);

        }
    }
}