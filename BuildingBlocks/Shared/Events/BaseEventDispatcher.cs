using Microsoft.Extensions.DependencyInjection;

namespace Shared.Events;

public class BaseEventDispatcher<TEvent> : IEventDispatcher<TEvent>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IDictionary<Type, ICollection<Type>> _handlers;

    public BaseEventDispatcher(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _handlers = new Dictionary<Type, ICollection<Type>>();
    }
    
    public async Task Dispatch(TEvent @event)
    {
        var handlerTypes = _handlers[typeof(TEvent)];
        var scope = _serviceScopeFactory.CreateScope();

        foreach (var handlerType in handlerTypes)
        {
            var handler = (IEventHandler<TEvent>) scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.Handle(@event);
        }
    }

    public Task Subscribe(Type eventType, Type handlerType)
    {
        throw new NotImplementedException();
    }
}