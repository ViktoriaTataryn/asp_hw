using AutoMapper;
using ht8.Data;
using ht8.DTOs.Inputs;
using ht8.DTOs.Outputs;
using ht8.Models;
using Microsoft.EntityFrameworkCore;

namespace ht8.Service;

public class FilmService :IFilmService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public FilmService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    

   public async Task<IEnumerable<FilmDTO>> GetFilms(int skip, int take)
   {
       return await _context.Films
           .Where(f => !f.DeletedAt.HasValue)
           .Select(f => _mapper.Map<FilmDTO>(f))
           .Skip(skip)
           .Take(take)
           .ToArrayAsync();
   }

    public async Task<FilmDTO?> GetFilmById(int id)
    {
        return await _context.Films
            .Where(f => f.ID == id && !f.DeletedAt.HasValue)
            .Select(f => _mapper.Map<FilmDTO>(f))
            .FirstOrDefaultAsync();
    }

    public async Task<FilmDTO> AddFilm(CreateFilmDTO createFilm)
    {
       var film = _mapper.Map<Film>(createFilm);
       film.CreatedAt = DateTime.Now;
       
       await _context.Films.AddAsync(film);
       await _context.SaveChangesAsync();
       return _mapper.Map<FilmDTO>(film);
    }

    public  async Task DeleteFilm(int id)
    {
        var film = await _context.Films.FindAsync(id);
        film.DeletedAt = DateTime.Now;
        await _context.SaveChangesAsync();
    }

 
}