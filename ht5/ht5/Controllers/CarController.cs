using Microsoft.AspNetCore.Mvc;
using ht5.Models;
using System;
using System.Reflection;

namespace ht5.Controllers;

[ApiController]
[Route("cars")]
public class CarController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetCars(int index, int take)
    {
        var cars = new List<Car>(capacity: 1000);
        for (int i = 0; i < 1000; i++)
        {
            var car = new Car()
            {
                Id = i,
                Brand = $"Car {i}",
                Model = "Model",
                Color = "Black",
                Year = new Random().Next(2010, 2024)
            };
            cars.Add(car);
        }
        var pagedCars = cars
            .Skip(index * take)
            .Take(take);
        return Ok(pagedCars);
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetCarById([FromRoute] int id) {
        var car = new Car()
        {
            Id = id,
            Brand = "Car",
            Model = "Model",
            Color = "Black",
            Year = new Random().Next(2010, 2024)
        };
        return Ok(car);
    }
    [HttpGet("/brands{Brand}")]
    public ActionResult<Car> GetCarByBrand([FromRoute] string Brand)
    {
        var car = new Car()
        {
            Id = 1,
            Brand = Brand,
            Model = "Model",
            Color = "Black",
            Year = new Random().Next(2010, 2024)
        };
        return Ok(car);
    }

    [HttpPost]
    public ActionResult<Car> AddCar([FromBody] Car car)
    {
        car.Id = new Random().Next(1, 1000000);
        return Created($"/cars/{car.Id}", car);
    }

    [HttpPost("{id}")]
    public ActionResult<int> DeleteCar([FromRoute] int id)
    {
        return Ok(id);
    }

    [HttpPut]
    public ActionResult<Car> UpdateCar([FromBody] Car car)
    {
        return Ok(car);
    }

    [HttpPatch("{id}")]
    public ActionResult<Car> UpdateColor([FromRoute] int id, [FromBody] string color)
    {
        var car = new Car()
        {
            Id = id,
            Brand = "Car",
            Model = "Model",
            Color = color,
            Year = new Random().Next(2010, 2024)
        };
        return Ok(car);
    }

    [HttpGet("/brands")]
    public ActionResult<IEnumerable<string>> GetBarnds(int index, int take)
    {
        var cars = new List<Car>(capacity: 1000);
        for (int i = 0; i < 1000; i++)
        {
            var car = new Car()
            {
                Id = i,
                Brand = $"Car {i}",
                Model = "Model",
                Color = "Black",
                Year = new Random().Next(2010, 2024)
            };
            cars.Add(car);
        }
        var brands = cars.Select(x => x.Brand)
            .Skip(index * take)
            .Take(take);

        return Ok(brands);
    }

}

