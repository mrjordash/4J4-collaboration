using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _service;

    public BooksController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<BookDto>> GetAll()
        => Ok(_service.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<BookDto> GetById(int id)
    {
        var book = _service.GetById(id);
        if (book is null) return NotFound(new { message = $"Book {id} not found" });
        return Ok(book);
    }

    [HttpPost]
    public ActionResult<BookDto> Create([FromBody] CreateBookRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = _service.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public ActionResult<BookDto> Update(int id, [FromBody] UpdateBookRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var updated = _service.Update(id, request);
        if (updated is null) return NotFound(new { message = $"Book {id} not found" });
        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);
        if (!deleted) return NotFound(new { message = $"Book {id} not found" });
        return NoContent();
    }
}
