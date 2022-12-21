using Ruinum.ECS.Systems.Game.Strategies;
using Entitas;

namespace Ruinum.ECS.Systems.States
{
    public sealed class MovementStrategySystem : EntityStrategySystemBase
    {
        public MovementStrategySystem(IContext<GameEntity> context) :
            base(context, GameMatcher.MovementStrategyCreate, GameMatcher.MovementStrategyProcess, GameComponentsLookup.MovementStrategyCreate, GameComponentsLookup.MovementStrategyProcess)
        {
        }
    }
}