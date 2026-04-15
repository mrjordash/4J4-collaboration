using Core.Entities;

namespace Core.Interfaces;

public interface IBookRepository
{
    IReadOnlyList<Book> GetAll();
    Book? GetById(int id);
    Book Add(Book book);
    bool Update(Book book);
    bool Delete(int id);
}

