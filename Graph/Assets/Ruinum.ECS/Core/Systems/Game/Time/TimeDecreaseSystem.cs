using Entitas;
using UnityEngine;

namespace Ruinum.ECS.Systems
{
    public class TimeDecreaseSystem : GroupExecuteSystem<GameEntity>
    {
        public TimeDecreaseSystem(IContext<GameEntity> context) : base(context, GameMatcher.Time) { }

        protected override void Execute(GameEntity entity)
        {
            entity.ReplaceTime(entity.time.Value - Time.deltaTime);
        }
    }
}