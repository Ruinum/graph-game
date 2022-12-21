namespace Ruinum.ECS.Systems.Features
{
    public sealed class EventSystems : Feature
    {
        public EventSystems(Contexts contexts)
        {
            Add(new GameEventSystems(contexts));
        }
    }
}