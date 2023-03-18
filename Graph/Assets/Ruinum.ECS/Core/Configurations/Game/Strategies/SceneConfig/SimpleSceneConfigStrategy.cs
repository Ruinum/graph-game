namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class SimpleSceneConfigStrategy : ISceneConfigStrategy
    {
        public SceneConfig Config;

        public bool TryGet(GameEntity entity, out SceneConfig result)
        {
            result = Config;

            return true;
        }
    }
}