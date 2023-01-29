using Ruinum.ECS.Configurations.Conditions.Entities.Float;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class ConditionModifierStrategy : ModifierStrategy
    {
        public IFloatValueCondition Condition;
        public ModifierStrategy TrueModifierStrategy;
        public ModifierStrategy FalseModifierStrategy;

        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            return Condition.IsConditionTrue(entity, currentValue)
                ? TrueModifierStrategy.TryGet(entity, currentValue, out result)
                : FalseModifierStrategy.TryGet(entity, currentValue, out result);
        }
    }
}