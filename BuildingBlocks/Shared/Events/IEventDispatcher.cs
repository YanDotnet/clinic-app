namespace Shared.Events;

public interface IEventDispatcher<in TEvent>
{
    Task Dispatch(TEvent @event);

    Task Subscribe(Type eventType, Type handlerType);
}