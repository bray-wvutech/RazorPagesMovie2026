using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data;

public interface IMovieRepo
{
    IEnumerable<Movie> GetAll();
    Movie? GetById(int id);
}