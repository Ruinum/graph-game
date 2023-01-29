using Entitas;

namespace Ruinum.ECS.Systems
{
    public sealed class TimeLoopSystem : GroupExecuteSystem<GameEntity>
    {
        public TimeLoopSystem(IContext<GameEntity> context) : base(context, GameMatcher.TimeLoop)
        {
        }

        protected override void Execute(GameEntity entity)
        {
            if (!entity.hasTime)
            {
                return;
            }
            var time = entity.time.Value;
            if (time > 0)
            {
                return;
            }
            if (!entity.hasStartTime)
            {
                return;
            }
            entity.ReplaceTime(entity.startTime.Value + time);
        }
    }
}