using Microsoft.Extensions.Logging;
using Movies.Core.Entities;

namespace Movies.Infrastructure.Data;

public class MovieContextSeed
{
    public static async Task SeedAsync(MovieContext movieContext, ILoggerFactory loggerFactory, int? retry = 0)
    {
        int retryForAvailability = retry!.Value;
        try
        {
            await movieContext.Database.EnsureCreatedAsync();
            //movieContext.Database.Migrate();

            if(!movieContext.Movies.Any())
            {
                movieContext.Movies.AddRange(GetMovies());
                await movieContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if(retryForAvailability < 3) 
            {
                retryForAvailability++;
                var log = loggerFactory.CreateLogger<MovieContextSeed>();
                log.LogError($"Exception occurred while connecting: {ex.Message}");
                await SeedAsync(movieContext, loggerFactory, retryForAvailability);
            }
        }
    }

    private static IEnumerable<Movie> GetMovies()
    {
        return new List<Movie>()
        {
            new Movie{ DirectorName = "James Cameron", ReleaseYear = "2009", Name = "Avatar"},
            new Movie{ DirectorName = "James Cameron", ReleaseYear = "1997", Name = "Titanic"},
            new Movie{ DirectorName = "Lee Tamahory", ReleaseYear = "2002", Name = "Die Another day"},
        };
    }
}