namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class NegateIfLessZeroModifierStrategy : ModifierStrategy
    {
        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            result = currentValue < 0 ? -currentValue : currentValue;
            return true;
        }
    }
}