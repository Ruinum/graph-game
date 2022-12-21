using Entitas;
using Ruinum.ECS.Integration.Entitas;
namespace Ruinum.ECS.Core.Systems
{
    public class NextFrameDestroySystem : ReactiveSystemExtended<GameEntity>
    {

        public NextFrameDestroySystem(IContext<GameEntity> context) : base(context) { }
        public NextFrameDestroySystem(ICollector<GameEntity> collector) : base(collector) { }
        
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.NextFrameDestroy);
        }
        
        protected override bool Filter(GameEntity entity)
        {
            return !entity.isDestroyed && entity.isNextFrameDestroy;
        }
        
        protected override void Execute(GameEntity entity)
        {
            entity.isDestroyed = true;
        }
    }
}