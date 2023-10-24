using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Queries
{
    public class GetMovieByDirectoNameQuery : IRequest<IEnumerable<MovieResponse>>
    {
        public string DirectorName { get; set; } = string.Empty;

        public GetMovieByDirectoNameQuery(string directorName)
        {
            DirectorName = directorName;
        }
    }
}