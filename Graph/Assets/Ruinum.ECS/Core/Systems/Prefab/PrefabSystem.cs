using System.Collections.Generic;
using Entitas;

using Ruinum.ECS.Core.Systems.Log;
using Ruinum.ECS.Scripts.Entities.Components.Game;
using Ruinum.ECS.Services.Interfaces;

using UnityEngine;

namespace Ruinum.ECS.Systems.Prefab
{
    public sealed class PrefabSystem : ReactiveSystem<GameEntity>
    {
        private readonly List<(GameEntityBehaviour, GameEntity)> _buffer = new List<(GameEntityBehaviour, GameEntity)>();
        private readonly IAssetService _assetService;

        public PrefabSystem(IContext<GameEntity> context, IAssetService assetService) : base(context)
        {
            _assetService = assetService;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Prefab);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPrefab;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            for (int i = 0, max = entities.Count; i < max; i++)
            {
                var entity = entities[i];
                var prefabComponent = entity.prefab;
                if (prefabComponent.Reference == null || !prefabComponent.Reference.RuntimeKeyIsValid())
                {
                    LogExtention.Log("Prefab reference is null. Entity " + entity);
                    continue;
                }
                if (!_assetService.TryGetAsset(prefabComponent.Reference, out GameObject asset))
                {
                    LogExtention.Error($"Prefab has not been preloaded. Entity {entity}");
                    continue;
                }
                var gameObject = entity.hasTransformPositionTo
                    ? SpawnPrefab(asset, entity.transformPositionTo.Position, entity.hasTransformRotationTo ? entity.transformRotationTo.Value : Quaternion.identity)
                    : SpawnPrefab(asset);
                var entityBehaviour = gameObject.GetComponent<GameEntityBehaviour>();
                if (entityBehaviour == null)
                {
                    LogExtention.Error("entityBehaviour is null " + entity);
                    continue;
                }
                entity.AddGameObject(gameObject);
                _buffer.Add((entityBehaviour, entity));
            }
            for (int i = 0, max = _buffer.Count; i < max; i++)
            {
                var (entityBehaviour, entity) = _buffer[i];
                entityBehaviour.SetEntity(entity);
            }
            _buffer.Clear();
        }

        private static GameObject SpawnPrefab(GameObject asset, Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(asset, position, rotation);
        }

        private static GameObject SpawnPrefab(GameObject asset)
        {
            return Object.Instantiate(asset);
        }
    }
}