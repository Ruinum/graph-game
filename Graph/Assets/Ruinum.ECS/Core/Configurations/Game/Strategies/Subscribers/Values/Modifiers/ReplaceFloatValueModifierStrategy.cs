using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public sealed class ReplaceFloatValueModifierStrategy : ModifierStrategy
    {
        public TargetStrategy Target;

        public override bool TryGet(GameEntity entity, float currentValue, out float result)
        {
            result = currentValue;
            if (!Target.TryGet(entity, out var target))
            {
                return false;
            }
            target.ReplaceFloatValue(currentValue);
            return true;
        }
    }
}