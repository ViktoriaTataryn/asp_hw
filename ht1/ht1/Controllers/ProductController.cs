using Microsoft.AspNetCore.Mvc;
using ht1.Models;
namespace ht1.Controllers;


public class ProductController :Controller
{
    public IActionResult ProductsList()
    {
        
        var product = new Product
        {
            Name = "Apple",
            Price=12,
            Description = "Fruit",
            CreatedDate = DateTime.Now,
        };

        ViewBag.Description=product.Description;
        ViewData["CreatedDate"] = product.CreatedDate;

        ViewBag.Category= new Category {
            Name = "Fruits",
            Sale=15,
           Description = "Fresh fruits"
        };

        return View(product);
    }
}
