using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Commands;

public class CreateMovieCommand : IRequest<MovieResponse>
{
    public string Name { get; set; } = string.Empty;
    public string DirectorName { get; set; } = string.Empty;
    public string ReleaseYear { get; set; } = string.Empty;
}
