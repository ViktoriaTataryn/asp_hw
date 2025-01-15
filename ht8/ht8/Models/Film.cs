namespace ht8.Models;

public class Film
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public Author Author { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}