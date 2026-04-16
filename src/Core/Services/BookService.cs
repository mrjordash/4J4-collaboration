using Core.DTOs;
using Core.Interfaces;
using Core.Mappers;

namespace Core.Services;

public class BookService(IBookRepository repository) : IBookService
{
    public IReadOnlyList<BookDto> GetAll()
        => repository.GetAll().Select(BookMapper.ToDto).ToList();

    public BookDto? GetById(int id)
    {
        var book = repository.GetById(id);
        return book is null ? null : BookMapper.ToDto(book);
    }

    public BookDto Create(CreateBookRequest request)
    {
        //hgghjjkhfgghjhjkkj
        var entity = BookMapper.ToEntity(request);
        var created = repository.Add(entity);
        return BookMapper.ToDto(created);
    }

    public BookDto? Update(int id, UpdateBookRequest request)
    {
        var book = repository.GetById(id);
        if (book is null) return null;

        if (request.Title is not null) book.Title = request.Title.Trim();
        if (request.Author is not null) book.Author = request.Author.Trim();
        if (request.Year.HasValue) book.Year = request.Year.Value;
        if (request.Genre is not null) book.Genre = request.Genre.Trim();
        if (request.Pages.HasValue) book.Pages = request.Pages.Value;
        if (request.Isbn is not null) book.Isbn = request.Isbn.Trim();

        repository.Update(book);
        return BookMapper.ToDto(book);
    }

    public bool Delete(int id) => repository.Delete(id);
}
