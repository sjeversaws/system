using System.Text.Json.Serialization;

namespace Messages;

public class ComponentChanged
{
    [JsonPropertyName("systemId")]
    public string SytemId { get; set; }
    
    [JsonPropertyName("componentId")]
    public string ComponentId { get; set; }
}