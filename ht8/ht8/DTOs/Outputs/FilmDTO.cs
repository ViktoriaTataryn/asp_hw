namespace ht8.DTOs.Outputs;

public class FilmDTO
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public AuthorDTO AuthorDto { get; set; }
}