using Ruinum.ECS.Systems.Game.Strategies;
using Entitas;

namespace Ruinum.ECS.Systems.States
{
    public sealed class DestroyStrategySystem : EntityStrategySystemBase
    {
        public DestroyStrategySystem(IContext<GameEntity> context) :
            base(context, GameMatcher.DestroyStrategyCreate, GameMatcher.DestroyStrategyProcess, GameComponentsLookup.DestroyStrategyCreate, GameComponentsLookup.DestroyStrategyProcess)
        {
        }
    }
}