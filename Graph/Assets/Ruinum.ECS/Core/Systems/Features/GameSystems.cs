using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Game;
using Ruinum.ECS.Systems.Game.Strategies;
using Ruinum.ECS.Systems.Game.Subscribers;
using Ruinum.ECS.Systems.States;

namespace Ruinum.ECS.Systems.Features
{
    public sealed class GameSystems : Feature
    {
        public GameSystems(Contexts contexts, IGameServices services)
        {
            Add(new EntityStrategySystem(contexts.game));

            Add(new TargetPublisherSubscriberSystem(contexts.game));
            Add(new TargetEntityListMemberSystem(contexts.game));
            Add(new EntityListPublisherSubscriberSystem(contexts.game));

            Add(new GameValueSystems(contexts));

            Add(new PointPublisherSubscriberSystem(contexts.game));

            Add(new BeforeMovementStrategySystem(contexts.game));
            Add(new MovementSystems(contexts, services));
            Add(new MovementStrategySystem(contexts.game));
        }
    }
}