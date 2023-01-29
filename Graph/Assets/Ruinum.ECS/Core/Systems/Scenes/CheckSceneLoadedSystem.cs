using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Scenes
{
    public sealed class CheckSceneLoadedSystem : GroupExecuteSystem<GameEntity>
    {
        public CheckSceneLoadedSystem(IContext<GameEntity> context) : base(context, GameMatcher.SceneLoadProgress)
        {
        }
            
        protected override void Execute(GameEntity entity)
        {
            if (entity.sceneLoadProgress.Value.IsDone)
            {
                entity.isSceneLoaded = true;
            }
        }
    }
}