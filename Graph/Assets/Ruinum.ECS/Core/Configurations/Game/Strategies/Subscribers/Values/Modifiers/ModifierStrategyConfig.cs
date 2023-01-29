namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class ModifierStrategyConfig : InitializableSerializedConfig, IModifierStrategy
    {
        public IModifierStrategy Strategy;

        public bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            return Strategy.TryGet(entity, currentValue, out result);
        }
    }
}