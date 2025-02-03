using System.Runtime.Intrinsics.X86;
using Animals.API.DTOs.Outputs;
using Animals.API.Filters;
using Animals.API.Interfaces;
using Animals.API.Models;
using Animals.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Animals.API.Controllers;
[ApiController]
[Route("api/animals")]
public class AnimalsController: ControllerBase
{
   private readonly IAnimalService _animalService;

   public AnimalsController(IAnimalService animalService)
   {
      _animalService = animalService;
   }

   
   [HttpGet]
   [TimeFilter]

   public ActionResult<IEnumerable<Animal>> GetAnimals()
   {
      Thread.Sleep(1000);
      var animal =  _animalService.GetAnimals();
      return Ok(animal);
      
   }

   [HttpGet("{id}")]
   public  ActionResult<Animal> GetAnimal([FromRoute]int id)
   {
      var animal = _animalService.GetAnimalById(id);
      return Ok(animal);
   }

   [HttpPost]
   public ActionResult<Animal> AddAnimal([FromBody]Animal animal)
   {
     _animalService.AddAnimal(animal);
     return Created($"api/animals/{animal.Id}", animal);
      
   }

   [HttpGet("/test")]
   [TimeFilter]
   public ActionResult TestEndpoint()
   {
      Thread.Sleep(1000);
      return Ok("test");
   }
}