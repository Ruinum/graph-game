using System.Collections.Generic;
using Entitas;

using Ruinum.ECS.Core.Systems.Log;
using Ruinum.ECS.Integration.Entitas;
using Ruinum.ECS.Services.Interfaces;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Ruinum.ECS.Systems.Assets
{
    public sealed class UnloadAssetsByLabelSystem : ReactiveSystemExtended<GameEntity>
    {
        private readonly IAssetService assetService;

        public UnloadAssetsByLabelSystem(IContext<GameEntity> context, IAssetService assetService) : base(context)
        {
            this.assetService = assetService;
        }
        
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.UnloadAssetsByLabel);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasUnloadAssetsByLabel;
        }

        protected override void Execute(GameEntity e)
        {
            if (e.hasLoadAssetsOperation)
            {
                LogExtention.Error($"{Time.deltaTime} Entity {e} already has LoadAssetsOperation");
                return;
            }
            var operation = assetService.UnloadAsync(e.unloadAssetsByLabel.Labels, Addressables.MergeMode.Union);
            e.AddLoadAssetsOperation(operation);
            operation.Completed += m => OperationOnCompleted(m, e);
        }


        private static void OperationOnCompleted(AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle, GameEntity entity)
        {
            LogExtention.Log("LoadGameSceneAssetsSystem OperationOnCompleted");
            entity.AddLoadAssetsOperationCompleted(asyncOperationHandle.Status);
        }
    }
}