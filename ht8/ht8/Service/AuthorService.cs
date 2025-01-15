using AutoMapper;
using ht8.Data;
using ht8.DTOs.Inputs;
using ht8.DTOs.Outputs;
using ht8.Models;
using Microsoft.EntityFrameworkCore;

namespace ht8.Service;

public class AuthorService : IAuthorService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AuthorService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<AuthorDTO>> GetAuthors(int skip, int take)
    {
        return await _context.Authors
            .Where(a => !a.DeletedAt.HasValue)
            .Select(a => _mapper.Map<AuthorDTO>(a))
            .Skip(skip)
            .Take(take)
            .ToArrayAsync();
    }

    public async Task<AuthorDTO?> GetAuthorById(int id)
    {
        return await _context.Authors
            .Where(a =>a.DeletedAt.HasValue && a.Id == id )
            .Select(a => _mapper.Map<AuthorDTO>(a))
            .FirstOrDefaultAsync();
    }

    public async Task<AuthorDTO> AddAuthor(CreateAuthorDTO createAuthorDto)
    {
        var author = _mapper.Map<Author>(createAuthorDto);
        author.Created = DateTime.Now;
        
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
        return _mapper.Map<AuthorDTO>(author);
    }

    public async Task DeleteAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        author.DeletedAt = DateTime.Now;
        await _context.SaveChangesAsync();
    }
}