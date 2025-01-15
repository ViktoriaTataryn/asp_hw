using ht8.DTOs.Inputs;
using ht8.DTOs.Outputs;

namespace ht8.Service;

public interface IAuthorService
{
    Task< IEnumerable<AuthorDTO>> GetAuthors(int skip, int take);
    Task<AuthorDTO?> GetAuthorById(int id);
    Task< AuthorDTO> AddAuthor(CreateAuthorDTO createAuthorDto);
    Task DeleteAuthor(int id);
}