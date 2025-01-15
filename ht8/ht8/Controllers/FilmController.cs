using ht8.DTOs.Inputs;
using ht8.DTOs.Outputs;
using ht8.Service;
using Microsoft.AspNetCore.Mvc;

namespace ht8.Controllers;

[ApiController]
[Route("api/film")]
public class FilmController : ControllerBase
{
    private readonly IFilmService _filmService;

    public FilmController( IFilmService filmService)
    {
   
        _filmService = filmService;
    }

    [HttpGet("film")]
    public async Task<ActionResult<IEnumerable<FilmDTO>>> GetFilms(int skip, int take)
    {
        var films= await _filmService.GetFilms(skip, take);
        return Ok(films);
    }

    [HttpGet("film/{id}")]
    public async Task<ActionResult<FilmDTO>> GetFilmById([FromRoute]int id)
    {
        var film = await _filmService.GetFilmById(id);
        return Ok(film);
    }

    [HttpPost("film")]
    public async Task<ActionResult<FilmDTO>> AddFilm([FromBody]CreateFilmDTO film)
    {
        var createdFilm = await _filmService.AddFilm(film);
        return Created($"/api/film/{film}", createdFilm);
    }

    [HttpDelete("film/{id}")]
    public async Task<ActionResult> DeleteFilm([FromRoute] int id)
    {
        await _filmService.DeleteFilm(id);
        return Ok();
    }
}