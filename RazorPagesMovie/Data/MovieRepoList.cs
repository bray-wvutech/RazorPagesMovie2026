using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Data;

public class MovieRepoList : IMovieRepo
{
    private readonly List<RazorPagesMovie.Models.Movie> _movies;

    public MovieRepoList()
    {
        _movies = new List<Models.Movie>
        {
            new Models.Movie { Id = 1, Title = "When Harry Met Sally", ReleaseDate = DateTime.Parse("1989-2-12"), Genre = "Romantic Comedy", Price = 7.99M },
            new Models.Movie { Id = 2, Title = "Ghostbusters ", ReleaseDate = DateTime.Parse("1984-3-13"), Genre = "Comedy", Price = 8.99M },
            new Models.Movie { Id = 3, Title = "Ghostbusters 2", ReleaseDate = DateTime.Parse("1986-2-23"), Genre = "Comedy", Price = 9.99M },
            new Models.Movie { Id = 4, Title = "Rio Bravo", ReleaseDate = DateTime.Parse("1959-4-15"), Genre = "Western", Price = 3.99M }
        };
    }

    public IEnumerable<RazorPagesMovie.Models.Movie> GetAll()
    {
        return _movies.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToList();
    }

    public async Task<IEnumerable<RazorPagesMovie.Models.Movie>> GetAllAsync()
    {
        return await Task.FromResult(_movies.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToList());
    }

    public RazorPagesMovie.Models.Movie? GetById(int id)
    {
        return _movies.FirstOrDefault(m => m.Id == id);
    }

    public async Task<RazorPagesMovie.Models.Movie?> GetByIdAsync(int id)
    {
        return await Task.FromResult(_movies.FirstOrDefault(m => m.Id == id));
    }
}
