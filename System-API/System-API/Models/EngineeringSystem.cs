namespace SystemA_API.Models;

public interface IEngineeringSystem
{
    string Id { get; set; }
    List<EngineeringModel> Models { get; set; }
}

public class EngineeringSystem : IEngineeringSystem
{
    public string Id { get; set; }
    public List<EngineeringModel> Models { get; set; } = new List<EngineeringModel>();
}