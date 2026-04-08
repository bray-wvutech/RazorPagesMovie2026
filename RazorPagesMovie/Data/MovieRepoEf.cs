using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Data;

public class MovieRepoEf : IMovieRepo
{
    private readonly RazorPagesMovieContext _context;

    public MovieRepoEf(RazorPagesMovieContext context)
    {
        _context = context;
    }

    public IEnumerable<RazorPagesMovie.Models.Movie> GetAll()
    {
        return _context.Movie.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToList();
    }

    public async Task<IEnumerable<RazorPagesMovie.Models.Movie>> GetAllAsync()
    {
        return await _context.Movie.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToListAsync();
    }

    public RazorPagesMovie.Models.Movie? GetById(int id)
    {
        return _context.Movie.FirstOrDefault(m => m.Id == id);
    }

    public async Task<RazorPagesMovie.Models.Movie?> GetByIdAsync(int id)
    {
        return await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
    }
}
