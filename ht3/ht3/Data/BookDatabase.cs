using ht3.Models;
using Microsoft.AspNetCore.Identity;
namespace ht3.Data
{
    public class BookDatabase : IDatabase<Book>
    {
        private readonly List<Book> _book;
        private static int _counter = 0;
        public BookDatabase()
        {
            _book = new List<Book>();
        }
        public void Add(Book item)
        {
           
            item.Id = ++_counter;
            _book.Add(item);
        }

        public void Delete(Book item)
        {
            _book.RemoveAll(x => x.Id == item.Id);
        }

        public IEnumerable<Book> Get()
        {
            return _book;
        }

        public void Update(Book oldbook, Book book)
        {
            int index = _book.FindIndex(x => x.Id == oldbook.Id);
           
                _book[index] = book;
            
        }
    

}
}
