using ht8.DTOs.Inputs;
using ht8.DTOs.Outputs;
using ht8.Models;
using ht8.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ht8.Controllers;

[ApiController]
[Route("api/authors")]

public class AuthorController: ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet("authors")]
    public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors(int skip, int take)
    {
        var authors = await _authorService.GetAuthors(skip, take);
        return Ok(authors);
    }

    [HttpGet("author/{id}")]
    public async Task<ActionResult<AuthorDTO>> GetAuthorById([FromRoute] int id)
    {
        var author = await _authorService.GetAuthorById(id);
        return Ok(author);
    }

    [HttpPost("author")]
    public async Task<ActionResult<AuthorDTO>> AddAuthor([FromBody] CreateAuthorDTO createdAuthor)
    {
        var author = await _authorService.AddAuthor(createdAuthor);
        return Created($"/api/authors/{createdAuthor}", author);
    }

    [HttpDelete("author/{id}")]
    public async Task<ActionResult> DeleteAuthor([FromRoute] int id)
    {
        await _authorService.DeleteAuthor(id);
        return Ok();
    }
}