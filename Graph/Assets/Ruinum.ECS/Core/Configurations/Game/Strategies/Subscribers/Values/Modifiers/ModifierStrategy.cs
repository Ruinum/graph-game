namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public abstract class ModifierStrategy : IModifierStrategy
    {
        public abstract bool TryGet(GameEntity entity, float currentValue, out float result);
    }
}
 