namespace Ruinum.ECS.Configurations.Conditions.Entities.Float
{
    public sealed class AllFloatValueCondition : FloatValueContainerCondition
    {
        protected override bool IsTrue(GameEntity entity, float value)
        {
            for (int i = 0, max = Conditions.Length; i < max; i++)
            {
                if (!Conditions[i].IsConditionTrue(entity, value))
                {
                    return false;
                }
            }
            return true;
        }
    }
}