using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Pages;

public class IndexModel : PageModel
{
    private readonly IMovieRepo _repo;

    public IEnumerable<RazorPagesMovie.Models.Movie> Movies { get; set; } = default!;

    public IndexModel(IMovieRepo repo)
    {
        _repo = repo;
    }

    //public void OnGet()
    //{
    //    Movies = _repo.GetAll();
    //}

    public async void OnGetAsync()
    {
        Movies = await _repo.GetAllAsync();
    }
}
