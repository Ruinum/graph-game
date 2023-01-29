namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class NegateModifierStrategy : ModifierStrategy
    {
        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            result = -currentValue;
            return true;
        }
    }
}