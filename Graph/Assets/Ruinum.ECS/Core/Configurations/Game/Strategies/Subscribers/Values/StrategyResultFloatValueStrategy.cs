namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class StrategyResultFloatValueStrategy : FloatValueBaseStrategy
    {
        public IFloatValueStrategy TrueStrategy;
        public IFloatValueStrategy FalseStrategy = new SimpleFloatValueStrategy {Value = 0};

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (TrueStrategy.TryGet(entity, out var trueValue))
            {
                value = trueValue;
                return true;
            }
            if (FalseStrategy.TryGet(entity, out var falseValue))
            {
                value = falseValue;
                return true;
            }
            if(Logging) LogErrorNotFound(nameof(falseValue), (nameof(entity), entity));
            value = default;
            return false;
        }
    }
}