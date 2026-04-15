using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class CreateBookRequest
{
    [Required]
    [StringLength(1000, MinimumLength = 5)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Author { get; set; } = string.Empty;

    [Range(1000, 9999)]
    public int Year { get; set; }

    [Required]
    [StringLength(50)]
    public string Genre { get; set; } = string.Empty;

    [Range(1, 10000)]
    public int Pages { get; set; }

    [StringLength(20)]
    public string? Isbn { get; set; }
}
