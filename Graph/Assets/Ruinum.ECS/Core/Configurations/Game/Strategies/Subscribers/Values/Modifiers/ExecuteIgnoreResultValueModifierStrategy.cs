namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class ExecuteIgnoreResultValueModifierStrategy : ModifierStrategy
    {
        public ModifierStrategy Modifier;

        public override bool TryGet(GameEntity entity, float currentValue, out float resultValue)
        {
            Modifier.TryGet(entity, currentValue, out _);
            resultValue = currentValue;
            return true;
        }
    }
}