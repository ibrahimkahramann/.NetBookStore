using FluentValidation;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(query => query.Model.Name).NotEmpty().MinimumLength(4).When( x => x.Model.Name != string.Empty);
        }
    }
}