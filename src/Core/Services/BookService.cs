using Core.DTOs;
using Core.Interfaces;
using Core.Mappers;

namespace Core.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public IReadOnlyList<BookDto> GetAll()
        => _repository.GetAll().Select(BookMapper.ToDto).ToList();

    public BookDto? GetById(int id)
    {
        var book = _repository.GetById(id);
        return book is null ? null : BookMapper.ToDto(book);
    }

    public BookDto Create(CreateBookRequest request)
    {
        var entity = BookMapper.ToEntity(request);
        var created = _repository.Add(entity);
        return BookMapper.ToDto(created);
    }

    public BookDto? Update(int id, UpdateBookRequest request)
    {
        var book = _repository.GetById(id);
        if (book is null) return null;

        if (request.Title is not null) book.Title = request.Title.Trim();
        if (request.Author is not null) book.Author = request.Author.Trim();
        if (request.Year.HasValue) book.Year = request.Year.Value;
        if (request.Genre is not null) book.Genre = request.Genre.Trim();
        if (request.Pages.HasValue) book.Pages = request.Pages.Value;
        if (request.Isbn is not null) book.Isbn = request.Isbn.Trim();

        _repository.Update(book);
        return BookMapper.ToDto(book);
    }

    public bool Delete(int id) => _repository.Delete(id);
}
