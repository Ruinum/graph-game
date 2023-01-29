using Ruinum.ECS.Services.Interfaces;
using Entitas;

namespace Ruinum.ECS.Systems.Scenes
{
    public sealed class CheckScenesLoadingSystem : IExecuteSystem
    {
        private readonly GameContext _context;
        private readonly ILoaderService _service;
        private readonly IGroup<GameEntity> _loadingOperations;
        private readonly IGroup<GameEntity> _loadingScenes;

        public CheckScenesLoadingSystem(GameContext context, ILoaderService service) 
        {
            _context = context;
            _service = service;
            _loadingScenes = _context.GetGroup(GameMatcher.AllOf(GameMatcher.SceneLoadProgress).NoneOf(GameMatcher.SceneLoaded));
            _loadingOperations = context.GetGroup(GameMatcher.AllOf(GameMatcher.LoadAssetsOperation).NoneOf(GameMatcher.LoadAssetsOperationCompleted));
        }
        
        private void SetActive(bool active)
        {
            _context.isSceneLoadingProcess = active;
        }

        public void Execute()
        {
            SetActive(_loadingOperations.count > 0 || _loadingScenes.count > 0);
        }
    }
} 