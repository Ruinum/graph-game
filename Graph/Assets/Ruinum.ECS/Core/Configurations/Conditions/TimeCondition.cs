using Ruinum.ECS.Configurations.Conditions.Entities;

namespace Ruinum.ECS.Core.Conditions
{
    public class TimeCondition : FloatEqualCondition
    {
        protected override bool IsTrue(GameEntity entity)
        {
            return entity.hasTime && IsEqual(entity.time.Value);
        }
    }
}