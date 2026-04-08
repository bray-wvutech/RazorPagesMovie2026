using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using RazorPagesMovie.Utils;

namespace RazorPagesMovie.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        private readonly IWebHostEnvironment _env;

        public CreateModel(RazorPagesMovie.Data.RazorPagesMovieContext context, 
            IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // here is where we are dealing with the image file
            // HttpContext is a built in object we have access to
            // it has a Request object that has all kinds of info
            // about the request that got us here in the OnPost
            // including information about the form that submitted the request
            // the Form object has a list of Files
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                // PictureUri is the model property where we are storing
                // the path to our image

                // PictureHelper.UploadNewImage is a utility function
                // written by us to take an environment variable
                // and a file and rename the file and place it in a
                // specific folder then return a path to it

                Movie.ImageUri = PictureHelper.UploadNewImage(_env,
                    HttpContext.Request.Form.Files[0]);
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
