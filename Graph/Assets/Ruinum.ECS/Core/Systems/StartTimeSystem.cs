using Entitas;
using Ruinum.ECS.Integration.Entitas;

namespace Ruinum.ECS.Systems 
{
    public class StartTimeSystem : ReactiveSystemExtended<GameEntity>
    {
        public StartTimeSystem(IContext<GameEntity> context) : base(context) { }

        protected override void Execute(GameEntity e)
        {
            e.ReplaceStartTime(e.time.Value);
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.hasStartTime && entity.hasTime;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Time);
        }
    }
}