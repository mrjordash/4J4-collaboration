using System;
using System.Linq;
using Core.DTOs;
using Core.Interfaces;
using Core.Mappers;

namespace Core.Services;

public class BookService(IBookRepository repository) : IBookService
{
    public IReadOnlyList<BookDto> GetAll(string? genre = null, int? year = null)
    {
        var books = repository.GetAll().AsEnumerable();
        if (!string.IsNullOrWhiteSpace(genre))
        {
            var g = genre.Trim();
            books = books.Where(b => !string.IsNullOrWhiteSpace(b.Genre) && string.Equals(b.Genre.Trim(), g, StringComparison.OrdinalIgnoreCase));
        }
        if (year.HasValue)
        {
            books = books.Where(b => b.Year == year.Value);
        }
        return books.Select(BookMapper.ToDto).ToList();
    }

    public BookDto? GetById(int id)
    {
        var book = repository.GetById(id);
        return book is null ? null : BookMapper.ToDto(book);
    }

    public BookDto Create(CreateBookRequest request)
    {
        // Map request to entity !
        var entity = BookMapper.ToEntity(request);
        var created = repository.Add(entity);
        return BookMapper.ToDto(created);
    }

    public BookDto? Update(int id, UpdateBookRequest request)
    {
        var book = repository.GetById(id);
        if (book is null) return null;

        // TODO: This is a lot of IF!!!
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

