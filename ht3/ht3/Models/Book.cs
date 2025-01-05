namespace ht3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int NumOfPages { get; set; }
        public Author Author { get; set; } = new Author();
    }
}
