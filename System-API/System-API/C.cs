using SystemA_API.Models;

namespace SystemA_API;

public static class C
{
    public const string ModelEventsBus = "model_events";
    public const string ModelCreatedEvent = "model_created";
    public const string ModelUpdatedEvent = "model_updated";
    public const string ModelDeletedEvent = "model_deleted";
    
    public const string SystemA = "System A";
    public const string SystemB = "System B";
    public const string SystemC = "System C";
    public const string SystemD = "System D";
    public const string SystemE = "System E";

    public const string Model1 = "Model 1";
    public const string Model2 = "Model 2";
    public const string Model3 = "Model 3";
    public const string Model4 = "Model 4";
    public const string Model5 = "Model 5";

    public static IEngineeringSystem EngineeringSystemA = new EngineeringSystem
    {
        Id = SystemA, 
        Models = new List<EngineeringModel>() { new EngineeringModel { Id = Model1 } }
    };

    public static IEngineeringSystem EngineeringSystemB = new EngineeringSystem
    {
        Id = SystemB,
        Models = new List<EngineeringModel>() { new EngineeringModel { Id = Model2 } }
    };
    
    public static IEngineeringSystem EngineeringSystemC = new EngineeringSystem
    {
        Id = SystemC,
        Models = new List<EngineeringModel>() { new EngineeringModel { Id = Model3 } }
    };
    
    public static IEngineeringSystem EngineeringSystemD = new EngineeringSystem
    {
        Id = SystemD,
        Models = new List<EngineeringModel>() { new EngineeringModel { Id = Model4 } }
    };
    
    public static IEngineeringSystem EngineeringSystemE = new EngineeringSystem
    {
        Id = SystemE,
        Models = new List<EngineeringModel>() { new EngineeringModel { Id = Model5 } }
    };
}