namespace Ruinum.ECS.Configurations.Game.Strategies.Texts
{
    public abstract class TextStrategy : ContextInitializable, ITextStrategy
    {
        public abstract bool TryGet(GameEntity entity, out string text);
    }
}