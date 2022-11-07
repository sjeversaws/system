namespace SystemA_API.Models;

public class EngineeringModel
{
    public string Id { get; set; }
    public List<string> Contains { get; set; } = new List<string>();
}