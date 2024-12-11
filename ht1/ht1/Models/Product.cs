namespace ht1.Models
{
    public class Product
    {
        public string Name {  get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category Category { get; set; }
    }
}
