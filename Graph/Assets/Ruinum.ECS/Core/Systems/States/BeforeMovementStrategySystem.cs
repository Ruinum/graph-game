using Ruinum.ECS.Systems.Game.Strategies;
using Entitas;

namespace Ruinum.ECS.Systems.States
{
    public sealed class BeforeMovementStrategySystem : EntityStrategySystemBase
    {
        public BeforeMovementStrategySystem(IContext<GameEntity> context) :
            base(context, GameMatcher.BeforeMovementStrategyCreate, GameMatcher.BeforeMovementStrategyProcess, GameComponentsLookup.BeforeMovementStrategyCreate, GameComponentsLookup.BeforeMovementStrategyProcess)
        {
        }
    }
}