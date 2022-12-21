using Entitas;
using Ruinum.ECS.Integration.Entitas;
namespace Ruinum.ECS.Core.Systems
{
    public class DestroySystem : ReactiveSystemExtended<GameEntity>
    {
        public DestroySystem(IContext<GameEntity> context) : base(context) { }
        public DestroySystem(ICollector<GameEntity> collector) : base(collector) { }
        
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed);
        }
        
        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroyed;
        }
        
        protected override void Execute(GameEntity entity)
        {
            entity.Destroy();
        }
    }
}