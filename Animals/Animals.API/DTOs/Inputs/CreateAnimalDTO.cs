namespace Animals.API.DTOs.Inputs;

public class CreateAnimalDTO
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string AnimalType { get; set; }
    public string Color { get; set; }
}