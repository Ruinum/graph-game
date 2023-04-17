namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class PercentValueStrategy : FloatValueBaseStrategy
    {
        public IFloatValueStrategy MaxValue;
        public IFloatValueStrategy CurrentValue;

        public override bool TryGet(GameEntity entity, out float value)
        {
            value = default;
            if (!MaxValue.TryGet(entity, out var maxValue)) { return false; }
            if (!CurrentValue.TryGet(entity, out var currentValue)) { return false; }

            value = currentValue / maxValue;
            return true;
        }
    }
}