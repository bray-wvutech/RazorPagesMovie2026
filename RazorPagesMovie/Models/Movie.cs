using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Movie
{
    public int Id { get; set; }


    public string? Title { get; set; }


    [Display(Name = "Changed Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    

    public string? Genre { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Required]
    [Range(1, 100)]
    public int Rank { get; set; } = 50;

    public string? ImageUri { get; set; }
}