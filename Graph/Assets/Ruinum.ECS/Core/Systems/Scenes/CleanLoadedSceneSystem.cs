using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Scenes
{
    public sealed class CleanLoadedSceneSystem : ReactiveSystemExtended<GameEntity>
    {
        public CleanLoadedSceneSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.SceneLoaded);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isSceneLoaded && entity.hasSceneLoadMode && entity.hasSceneLoadProgress && entity.sceneLoadProgress.Value.IsDone;
        }

        protected override void Execute(GameEntity e)
        {
            e.RemoveSceneLoadMode();
            e.RemoveSceneLoadProgress();
        }
    }
}