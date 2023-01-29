namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class ModifierChainStrategy : ModifierStrategy
    {
        public IModifierStrategy[] Modifiers;

        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            result = currentValue;
            for (int i = 0, max = Modifiers.Length; i < max; i++)
            {
                if (Modifiers[i].TryGet(entity, result, out var newValue))
                {
                    result = newValue;
                }
            }
            return true;
        }
    }
}