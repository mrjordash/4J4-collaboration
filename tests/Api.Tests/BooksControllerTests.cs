using System;
using FluentAssertions;
using Infrastructure.Repositories;
using Core.Services;
using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Api.Tests;

public class BooksControllerTests
{
    private static BooksController BuildController()
    {
        var repo = new InMemoryBookRepository();
        var service = new BookService(repo);
        return new BooksController(service);
    }

    [Fact]
    public void GetAll_InvalidYear_Returns400()
    {
        var controller = BuildController();

        var result = controller.GetAll(null, "notanumber");

        result.Result.Should().BeOfType<BadRequestObjectResult>();
        var bad = result.Result as BadRequestObjectResult;
        bad!.Value.Should().BeEquivalentTo(new { error = "Invalid year" });
    }
}
