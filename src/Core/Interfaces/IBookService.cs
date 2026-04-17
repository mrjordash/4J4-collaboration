using Core.DTOs;

namespace Core.Interfaces;

public interface IBookService
{
    IReadOnlyList<BookDto> GetAll(string? genre = null, int? year = null);
    BookDto? GetById(int id);
    BookDto Create(CreateBookRequest request);
    BookDto? Update(int id, UpdateBookRequest request);
    bool Delete(int id);
}

