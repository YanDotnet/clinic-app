namespace Shared.Events;

public interface IEventHandler<in TEvent>
{
    Task Handle(TEvent @event);
}