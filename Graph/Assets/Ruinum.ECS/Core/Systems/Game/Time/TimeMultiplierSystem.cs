using Entitas;
using Ruinum.ECS.Integration.Entitas;

namespace Ruinum.ECS.Systems
{
    public sealed partial class TimeMultiplierSystem : ReactiveSystemExtended<GameEntity>
    {
        public TimeMultiplierSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TimeMultiplier);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasStartTime && entity.hasTime;
        }

        protected override void Execute(GameEntity entity)
        {
            var time = entity.time.Value * entity.timeMultiplier.Value;
            entity.ReplaceTime(time);
            if (entity.hasStartTime)
            {
                entity.RemoveStartTime();
            }
        }
    }
}