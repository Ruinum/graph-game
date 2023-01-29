namespace Ruinum.ECS.Configurations.Conditions.Entities.Float
{
    public interface IFloatValueCondition
    {
        bool IsConditionTrue(GameEntity entity, float value);
    }
}
