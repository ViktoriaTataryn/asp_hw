using Animals.API.DTOs.Inputs;
using Animals.API.DTOs.Outputs;
using Animals.API.Interfaces;
using Animals.API.Models;

namespace Animals.API.Services;

public class AnimalService : IAnimalService
{
    private readonly List<Animal> _animals ;
    private static int _currentId = 1;
    public AnimalService(){
        _animals = new List<Animal>();
    }
    public void AddAnimal(Animal animal)
    {
        animal.Id = _currentId++;
        _animals.Add(animal);
    }
    public IEnumerable<Animal> GetAnimals()
    {
        return _animals;
    }

    public Animal GetAnimalById(int id)
    {
        return _animals.Single(a=>a.Id==id);
    }

    /*public void AddAnimal(CreateAnimalDTO animalDTO)
    {
        var animal = new Animal()
        {
            Id = _currentId++,
            Name = animalDTO.Name,
            Age = animalDTO.Age,
            AnimalType = animalDTO.AnimalType,
        };
        _animals.Add(animal);
    }*/

    /*IEnumerable<AnimalDTO> IAnimalService.GetAnimals()
    {
        return _animals.Select(animal => new AnimalDTO()
        {
            Id = animal.Id,
            Name = animal.Name,
            Age = animal.Age,
            AnimalType = animal.AnimalType,
        });
    }*/

    /*AnimalDTO IAnimalService.GetAnimalById(int id)
    {
        var animal = _animals.FirstOrDefault(animal => animal.Id == id);
        return new AnimalDTO()
        {
            Id = animal.Id,
            Name = animal.Name,
            Age = animal.Age,
            AnimalType = animal.AnimalType,
        };
    }*/

  
}