using System.Collections.Generic;
using Ruinum.ECS.Services.Interfaces;
using Entitas;

namespace Ruinum.ECS.Systems.Scenes
{
    public sealed class CheckScenesStatusSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly ILoaderService _service;
        private readonly IGroup<GameEntity> _loadingScenes;
        private readonly IGroup<GameEntity> _loadOperations;

        private readonly List<GameEntity> _loadOperationsBuffer = new List<GameEntity>();
        private readonly List<GameEntity> _loadSceneBuffer = new List<GameEntity>();

        public CheckScenesStatusSystem(GameContext gameContext, ILoaderService service)
        {
            _gameContext = gameContext;
            _service = service;
            _loadingScenes = gameContext.GetGroup(GameMatcher.SceneLoadProgress);
            _loadOperations = gameContext.GetGroup(GameMatcher.LoadAssetsOperation);
        }
 
        public void Execute()
        {
            if (!_gameContext.isSceneLoadingProcess)
            {          
                _service.IsActive = false;
                return;
            }
            _service.IsActive = true;
            _loadOperations.GetEntities(_loadOperationsBuffer);
            _loadingScenes.GetEntities(_loadSceneBuffer);
            var count = 0;
            var operationsCount = CalcOperations(_loadOperationsBuffer);
            var scenesCount = CalcScenes(_loadSceneBuffer);
            if (_loadOperationsBuffer.Count > 0)
            {
                count++;
            }
            if (_loadSceneBuffer.Count > 0)
            {
                count++;
            }
            
            _service.UpdateProgress((operationsCount + scenesCount) / count);
        }

        private float CalcScenes(List<GameEntity> entities)
        {
            var loadOperationsPercent = 0f;
            var loadOperationsCount = entities.Count;
            if (loadOperationsCount != 0)
            {
                var loadOperationsPercentSum = 0.0f;
                for (int i = 0; i < loadOperationsCount; i++)
                {
                    var operation = entities[i].sceneLoadProgress.Value;
                    if (operation.IsValid())
                    {
                        loadOperationsPercentSum += operation.PercentComplete;
                    }
                    else
                    {
                        loadOperationsCount--;
                    }
                }

                loadOperationsPercent = loadOperationsPercentSum / loadOperationsCount;
            }
            return loadOperationsPercent;
        }
        
        private float CalcOperations(List<GameEntity> entities)
        {
            var loadOperationsPercent = 0f;
            var loadOperationsCount = entities.Count;
            if (loadOperationsCount != 0)
            {
                var loadOperationsPercentSum = 0.0f;
                for (int i = 0; i < loadOperationsCount; i++)
                {
                    loadOperationsPercentSum += entities[i].loadAssetsOperation.Operation.PercentComplete;
                }

                loadOperationsPercent = loadOperationsPercentSum / loadOperationsCount;
            }

            return loadOperationsPercent;
        }
    }
}