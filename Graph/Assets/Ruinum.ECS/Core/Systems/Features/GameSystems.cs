using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Game.Strategies;
using Ruinum.ECS.Systems.States;

namespace Ruinum.ECS.Systems.Features
{
    public sealed class GameSystems : Feature
    {
        public GameSystems(Contexts contexts, IGameServices services)
        {
            Add(new BeforeMovementStrategySystem(contexts.game));
            Add(new MovementSystems(contexts, services));
            Add(new MovementStrategySystem(contexts.game));

            Add(new EntityStrategySystem(contexts.game));
        }
    }
}