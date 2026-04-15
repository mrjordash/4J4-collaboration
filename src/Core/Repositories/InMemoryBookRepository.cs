using System.Collections.Concurrent;
using Core.Entities;
using Core.Interfaces;

namespace Core.Repositories;

public class InMemoryBookRepository : IBookRepository
{
    private readonly ConcurrentDictionary<int, Book> _books = new();
    private int _nextId;

    public InMemoryBookRepository()
    {
        Seed();
    }

    public IReadOnlyList<Book> GetAll()
        => _books.Values.OrderBy(b => b.Id).ToList();

    public Book? GetById(int id)
        => _books.TryGetValue(id, out var book) ? book : null;

    public Book Add(Book book)
    {
        book.Id = Interlocked.Increment(ref _nextId);
        book.CreatedAt = DateTime.UtcNow;
        _books[book.Id] = book;
        return book;
    }

    public bool Update(Book book)
    {
        if (!_books.ContainsKey(book.Id)) return false;
        _books[book.Id] = book;
        return true;
    }

    public bool Delete(int id) => _books.TryRemove(id, out _);

    private void Seed()
    {
        Add(new Book { Title = "The Pragmatic Programmer", Author = "Andrew Hunt, David Thomas", Year = 1999, Genre = "Programming", Pages = 320, Isbn = "978-0201616224" });
        Add(new Book { Title = "Clean Code", Author = "Robert C. Martin", Year = 2008, Genre = "Programming", Pages = 464, Isbn = "978-0132350884" });
        Add(new Book { Title = "Refactoring", Author = "Martin Fowler", Year = 2018, Genre = "Programming", Pages = 448, Isbn = "978-0134757599" });
        Add(new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937, Genre = "Fantasy", Pages = 310, Isbn = "978-0547928227" });
        Add(new Book { Title = "1984", Author = "George Orwell", Year = 1949, Genre = "Dystopian", Pages = 328, Isbn = "978-0451524935" });
    }
}
