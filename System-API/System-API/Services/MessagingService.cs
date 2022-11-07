using System.Text.Json;
using Amazon;
using Amazon.EventBridge;
using Amazon.EventBridge.Model;
using Messages;
using SystemA_API.Models;

namespace SystemA_API.Services;

public interface IMessagingService
{
    Task<bool> PublishUpdated(EngineeringModel model);
}

public class MessagingService : IMessagingService
{
    private readonly IEngineeringSystem _system;
    
    public MessagingService(IEngineeringSystem system)
    {
        _system = system;
    }

    public async Task<bool> PublishUpdated(EngineeringModel model)
    {
        var componentChangedEvent = new ComponentChanged()
        {
            SytemId = _system.Id, 
            ComponentId = model.Id
        };
        
        var requestEntry = CreateRequestEntry(C.ModelUpdatedEvent, JsonSerializer.Serialize(componentChangedEvent));
        var response = await PutRequest(requestEntry);

        return response.FailedEntryCount > 0;
    }

    private PutEventsRequestEntry CreateRequestEntry(string detailType, string detail)
    {
        return new PutEventsRequestEntry()
        {
            Source = _system.Id,
            EventBusName = C.ModelEventsBus,
            DetailType = detailType,
            Detail = detail
        };
    }

    private async Task<PutEventsResponse> PutRequest(PutEventsRequestEntry requestEntry)
    {
        using var client = new AmazonEventBridgeClient(RegionEndpoint.USWest2);
        var request = new PutEventsRequest() { Entries = { requestEntry }};
        
        return await client.PutEventsAsync(request);
    }
}