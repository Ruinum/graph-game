using Ruinum.ECS.Systems.Game.Subscribers;

namespace Ruinum.ECS.Systems.Features
{
    public sealed class GameValueSystems : Feature
    {
        public GameValueSystems(Contexts contexts)
        {
            Add(new FloatValuePublisherSubscriberSystem(contexts.game));
            Add(new MaxFloatValuePublisherSubscriberSystem(contexts.game));
        }
    }
}