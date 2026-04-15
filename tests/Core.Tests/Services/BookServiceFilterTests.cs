using System;
using System.Linq;
using Core.DTOs;
using Infrastructure.Repositories;
using Core.Services;
using FluentAssertions;
using Xunit;

namespace Core.Tests.Services;

public class BookServiceFilterTests
{
    private static BookService BuildSut()
    {
        var repo = new InMemoryBookRepository();
        return new BookService(repo);
    }

    [Fact]
    public void GetAll_WithGenre_FiltersCaseInsensitive()
    {
        var sut = BuildSut();

        var books = sut.GetAll("programming", null);

        books.Should().NotBeEmpty();
        books.Should().OnlyContain(b => string.Equals(b.Genre, "Programming", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void GetAll_WithYear_Filters()
    {
        var sut = BuildSut();

        var books = sut.GetAll(null, 2018);

        books.Should().HaveCount(1);
        books[0].Year.Should().Be(2018);
    }

    [Fact]
    public void GetAll_WithCombinedFilters_ReturnsIntersection()
    {
        var sut = BuildSut();

        var books = sut.GetAll("Programming", 2018);

        books.Should().HaveCount(1);
        books[0].Title.Should().Contain("Refactoring");
    }
}
