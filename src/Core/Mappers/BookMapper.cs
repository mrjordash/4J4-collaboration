using Core.DTOs;
using Core.Entities;

namespace Core.Mappers;

public static class BookMapper
{
    public static BookDto ToDto(Book book) => new()
    {
        Id = book.Id,
        Title = book.Title,
        Author = book.Author,
        Year = book.Year,
        Genre = book.Genre,
        Pages = book.Pages,
        Isbn = book.Isbn,
        CreatedAt = book.CreatedAt,
    };

    public static Book ToEntity(CreateBookRequest request) => new()
    {
        Title = request.Title.Trim(),
        Author = request.Author.Trim(),
        Year = request.Year,
        Genre = request.Genre.Trim(),
        Pages = request.Pages,
        Isbn = request.Isbn?.Trim(),
    };
}
