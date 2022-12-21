using System.Collections.Generic;
using Entitas;

using Ruinum.ECS.Core.Systems.Log;
using Ruinum.ECS.Integration.Entitas;
using Ruinum.ECS.Services.Interfaces;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Ruinum.ECS.Systems.Assets
{
    public sealed class LoadAssetsByLabelSystem : ReactiveSystemExtended<GameEntity>
    {
        private readonly IAssetService _assetService;

        public LoadAssetsByLabelSystem(IContext<GameEntity> context, IAssetService assetService) : base(context)
        {
            _assetService = assetService;
        }
        
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.LoadAssetsByLabel);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasLoadAssetsByLabel;
        }

        protected override void Execute(GameEntity e)
        {

            if (e.hasLoadAssetsOperation)
            {
                LogExtention.Error($"{Time.deltaTime} Entity {e} already has LoadAssetsOperation");
                return;
            }
            var operation = _assetService.LoadAsync(e.loadAssetsByLabel.Labels, Addressables.MergeMode.Union);
            e.AddLoadAssetsOperation(operation);
            operation.Completed += m => OperationOnCompleted(m, e);
        }
        
        private static void OperationOnCompleted(AsyncOperationHandle<IList<Object>> asyncOperationHandle, GameEntity entity)
        {
            LogExtention.Log("LoadGameSceneAssetsSystem OperationOnCompleted");
            entity.AddLoadAssetsOperationCompleted(asyncOperationHandle.Status);
        }
    }
}