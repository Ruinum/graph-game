namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class SetValueModifierStrategy : ModifierStrategy
    {
        public IFloatValueStrategy Strategy;

        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            return Strategy.TryGet(entity, out result);
        }
    }
}