using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data;

public interface IMovieRepo
{
    IEnumerable<Movie> GetAll();
    Task<IEnumerable<Movie>> GetAllAsync();
    Movie? GetById(int id);
    Task<Movie?> GetByIdAsync(int id);
}