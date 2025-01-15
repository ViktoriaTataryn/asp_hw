using ht8.DTOs.Inputs;
using ht8.DTOs.Outputs;
using ht8.Models;

namespace ht8.Service;

public interface IFilmService
{
    Task< IEnumerable<FilmDTO>> GetFilms(int skip, int take);
    Task<FilmDTO?> GetFilmById(int id);
    Task< FilmDTO> AddFilm(CreateFilmDTO createFilm);
    Task DeleteFilm(int id);
    
}