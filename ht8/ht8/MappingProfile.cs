using AutoMapper;
using ht8.DTOs.Inputs;
using ht8.DTOs.Outputs;
using ht8.Models;

namespace ht8;

public class MappingProfile : Profile
{
  
    public MappingProfile()
    {
        CreateMap<CreateFilmDTO, Film>();   
        CreateMap<Film, FilmDTO>();
        
        CreateMap<CreateAuthorDTO, Author>();   
        CreateMap<Author, AuthorDTO>();
    }
    
}