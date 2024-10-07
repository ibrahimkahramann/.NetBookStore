using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetailQuery.GetGenreDetailQueryValidator
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);

        }
    }
}