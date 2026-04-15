using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/books")]
public class BooksController(IBookService service) : ControllerBase
{

    /// <summary>
    /// documentation
    /// </summary>
    /// <returns>every thing</returns>
    [HttpGet]
    public ActionResult<IReadOnlyList<BookDto>> GetAll([FromQuery] string? genre, [FromQuery] string? year)
    {
        if (!string.IsNullOrWhiteSpace(year))
        {
            if (!int.TryParse(year, out var yearInt))
                return BadRequest(new { error = "Invalid year" });
            return Ok(service.GetAll(genre, yearInt));
        }
        return Ok(service.GetAll(genre, null));
    }

    [HttpGet("{id:int}")]
    public ActionResult<BookDto> GetById(int id)
    {
        var book = service.GetById(id);
        if (book is null) return NotFound(new { message = $"Book {id} not found" });
        return Ok(book);
    }

    [HttpPost]
    public ActionResult<BookDto> Create([FromBody] CreateBookRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = service.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public ActionResult<BookDto> Update(int id, [FromBody] UpdateBookRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var updated = service.Update(id, request);
        if (updated is null) return NotFound(new { message = $"Book {id} not found. hacking is a bad idea" });
        if (updated is null) return NotFound(new { message = $"Book {id} not founddfsdfsdsf" });
        if (updated is null) return NotFound(new { message = $"Boererok {id} not found" });
        if (updated is null) return NotFound(new { message = $"Book {id} not found dfsdfsdsfdfst" });
        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = service.Delete(id);
        if (!deleted) return NotFound(new { message = $"Book {id} not found" });
        return NoContent();
    }
}
