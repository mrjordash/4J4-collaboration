using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class UpdateBookRequest
{
    [StringLength(200, MinimumLength = 1)]
    public string? Title { get; set; }

    [StringLength(100, MinimumLength = 1)]
    public string? Author { get; set; }

    [Range(1000, 9999)]
    public int? Year { get; set; }

    [StringLength(50)]
    public string? Genre { get; set; }

    [Range(1, 10000)]
    public int? Pages { get; set; }

    [StringLength(20)]
    public string? Isbn { get; set; }
}
