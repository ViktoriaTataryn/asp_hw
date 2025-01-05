using ht3.Models;
using ht3.Data;
using Microsoft.AspNetCore.Mvc;
namespace ht3.Controllers;

public class BookController : Controller
{
    private static readonly IDatabase<Book> _bookdatabase = new BookDatabase();
    static BookController()
    {

        _bookdatabase.Add(new Book() { Id = 1, Title = "The secret history", Author = new Author { Id = 1, FirstName = "Donna", LastName = "Tartt" }, Price = 430, NumOfPages = 459 });
        _bookdatabase.Add(new Book() { Id = 2, Title = "The lost symbol", Author = new Author { Id = 2, FirstName = "Dan", LastName = "Brown" }, Price = 358, NumOfPages = 546 });
        _bookdatabase.Add(new Book() { Id = 3, Title = "1984", Author = new Author { Id = 3, FirstName = "George", LastName = "Orwell" }, Price = 251, NumOfPages = 345 });
    }
    [HttpGet]
    public IActionResult GetBook()
    {
        var books = _bookdatabase.Get();
        return View(books);
    }
    public IActionResult AddBook()
    {
        return View();
    }
    public IActionResult DeleteBook(int id)
    {
        var book = _bookdatabase.Get().First(x => x.Id == id);
        return View(book);
    }
    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        _bookdatabase.Add(book);
        return RedirectToAction(nameof(GetBook));
    }
    [HttpPost]
    public IActionResult DeleteBook(Book book)
    {
        _bookdatabase.Delete(book);
        return RedirectToAction(nameof(GetBook));
    }
    public IActionResult UpdateBook(int id)
    {
        var book = _bookdatabase.Get().First(x => x.Id == id);
        return View(book);
    }
    [HttpPost]
    public IActionResult UpdateBook(Book book)
    {
        var oldBook = _bookdatabase.Get().First(x => x.Id == book.Id);
        _bookdatabase.Update(oldBook, book);
        return RedirectToAction(nameof(GetBook));
    }
}
