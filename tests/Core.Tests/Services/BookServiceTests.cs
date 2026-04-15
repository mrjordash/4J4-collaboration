using Core.DTOs;
using Core.Repositories;
using Core.Services;
using FluentAssertions;

namespace Core.Tests.Services;

public class BookServiceTests
{
    private static BookService BuildSut()
    {
        var repo = new InMemoryBookRepository();
        return new BookService(repo);
    }

    [Fact]
    public void GetAll_ReturnsSeededBooks()
    {
        var sut = BuildSut();

        var books = sut.GetAll();

        books.Should().NotBeEmpty();
        books.Should().OnlyContain(b => !string.IsNullOrWhiteSpace(b.Title));
    }

    [Fact]
    public void GetById_WhenMissing_ReturnsNull()
    {
        var sut = BuildSut();

        var result = sut.GetById(999);

        result.Should().BeNull();
    }

    [Fact]
    public void Create_AssignsIdAndCreatedAt()
    {
        var sut = BuildSut();
        var request = new CreateBookRequest
        {
            Title = "Domain-Driven Design",
            Author = "Eric Evans",
            Year = 2003,
            Genre = "Programming",
            Pages = 560,
            Isbn = "978-0321125217",
        };

        var created = sut.Create(request);

        created.Id.Should().BeGreaterThan(0);
        created.Title.Should().Be("Domain-Driven Design");
        created.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void Update_AppliesPartialChanges()
    {
        var sut = BuildSut();
        var created = sut.Create(new CreateBookRequest
        {
            Title = "Original", Author = "X", Year = 2020, Genre = "Tech", Pages = 100
        });

        var updated = sut.Update(created.Id, new UpdateBookRequest { Pages = 250 });

        updated.Should().NotBeNull();
        updated!.Pages.Should().Be(250);
        updated.Title.Should().Be("Original");
    }

    [Fact]
    public void Delete_RemovesBook()
    {
        var sut = BuildSut();
        var created = sut.Create(new CreateBookRequest
        {
            Title = "Ephemeral", Author = "X", Year = 2020, Genre = "Tech", Pages = 100
        });

        var deleted = sut.Delete(created.Id);
        var fetched = sut.GetById(created.Id);

        deleted.Should().BeTrue();
        fetched.Should().BeNull();
    }
}
