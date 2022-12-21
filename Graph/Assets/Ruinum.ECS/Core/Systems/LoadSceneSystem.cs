using System.Linq;
using Entitas;
using Ruinum.ECS.Integration.Entitas;
using Ruinum.ECS.Services.Interfaces;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace Ruinum.ECS.Core.Systems
{
    public class LoadSceneSystem : ReactiveSystemExtended<GameEntity>
    {
        private readonly IContext<GameEntity> _context;
        private readonly ISceneService _service;

        public LoadSceneSystem(IContext<GameEntity> context, ISceneService service) : base(context)
        {
            _context = context;
            _service = service;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.SceneLoadMode);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSceneLoadMode && entity.hasSceneConfig;
        }

        protected override void Execute(GameEntity entity)
        {
            var sceneConfig = entity.sceneConfig.Value;
            if (_service.TryLoadScene(sceneConfig.Reference, sceneConfig.LoadMode, out var progress))
            {
                progress.Completed += m => ProgressOnCompleted(m, entity);
                //entity.AddSceneLoadProgress(progress);
            }
            for (int i = 0; i < sceneConfig.AdditionalScenes.Length; i++)
            {
                var additional = sceneConfig.AdditionalScenes[i];
                var sceneEntity = _context.CreateEntity();
                sceneEntity.AddOwner(entity);
                if (_service.TryLoadScene(additional, LoadSceneMode.Additive, out var additionalProgress))
                {
                    additionalProgress.Completed += m => ProgressOnCompleted(m, sceneEntity);
                    //sceneEntity.AddSceneLoadProgress(additionalProgress);
                }
            }
        }

        private void ProgressOnCompleted(AsyncOperationHandle obj, GameEntity entity)
        {
            //entity.RemoveSceneLoadProgress();   
        }
    }
}