using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Pages
{
    [Authorize]
    public class Details2Model : PageModel
    {
        private readonly MovieRepoEf _repo;

        public Details2Model(RazorPagesMovieContext context)
        {
            _repo = new MovieRepoEf(context);
        }

        public Models.Movie MovieObject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            MovieObject = await _repo.GetByIdAsync(id);
            return Page();
        }

        // you can only have OnGet or OnGetAsync, not both at same time
        //public IActionResult OnGet(int id)
        //{
        //    MovieObject = _repo.GetById(id);
        //    return Page();
        //}
    }
}
