namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values.Modifiers
{
    public interface IModifierStrategy
    {
        bool TryGet(GameEntity entity, float currentValue, out float result);
    }
}