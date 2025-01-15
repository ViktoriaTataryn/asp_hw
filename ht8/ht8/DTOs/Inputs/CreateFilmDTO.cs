using ht8.DTOs.Outputs;

namespace ht8.DTOs.Inputs;

public class CreateFilmDTO
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public AuthorDTO Author { get; set; }
}