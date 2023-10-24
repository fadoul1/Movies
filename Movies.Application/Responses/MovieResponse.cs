namespace Movies.Application.Responses;

public class MovieResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DirectorName { get; set; } = string.Empty;
    public string ReleaseYear { get; set; } = string.Empty;
}