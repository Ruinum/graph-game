using Entitas;

namespace Ruinum.ECS.Systems.Game.Strategies
{
    public sealed class EntityStrategySystem : EntityStrategySystemBase
    {
        public EntityStrategySystem(IContext<GameEntity> context) 
            : base(context, GameMatcher.StrategyCreate, GameMatcher.StrategyProcess, GameComponentsLookup.StrategyCreate, GameComponentsLookup.StrategyProcess)
        {
        }
    }
}