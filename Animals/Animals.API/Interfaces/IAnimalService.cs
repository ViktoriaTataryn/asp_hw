using Animals.API.DTOs.Inputs;
using Animals.API.DTOs.Outputs;
using Animals.API.Models;

namespace Animals.API.Interfaces;

public interface IAnimalService
{
    void AddAnimal(Animal animal);
   
    IEnumerable<Animal> GetAnimals();
    Animal GetAnimalById(int id);
    //void AddAnimal(CreateAnimalDTO animalDTO);
   // IEnumerable<AnimalDTO> GetAnimals();
  
   // AnimalDTO GetAnimalById(int id);
}