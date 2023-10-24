using MediatR;
using Movies.Application.Mappers;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers;

public class GetMovieByDirectoNameHandler : IRequestHandler<GetMovieByDirectoNameQuery, IEnumerable<MovieResponse>>
{
    private readonly IMovieRepository _movieRepository;
    public GetMovieByDirectoNameHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IEnumerable<MovieResponse>> Handle(GetMovieByDirectoNameQuery request, CancellationToken cancellationToken)
    {
        var movieList = await _movieRepository.GetMoviesBydeirectorNameAsync(request.DirectorName);
        var movieResponsList = MovieMapper.Mapper.Map<IEnumerable<MovieResponse>>(movieList);

        return movieResponsList;
    }
}