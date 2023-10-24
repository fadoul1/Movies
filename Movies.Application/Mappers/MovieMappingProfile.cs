using AutoMapper;
using Movies.Application.Commands;
using Movies.Application.Responses;
using Movies.Core.Entities;

namespace Movies.Application.Mappers
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile() 
        {
            CreateMap<Movie, MovieResponse>().ReverseMap();
            CreateMap<Movie, CreateMovieCommand>().ReverseMap();
        }
    }

    public class MovieMapper
    {
        public static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MovieMappingProfile>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}