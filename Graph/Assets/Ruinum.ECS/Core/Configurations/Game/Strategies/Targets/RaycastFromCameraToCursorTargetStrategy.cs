using Ruinum.ECS.Configurations.Game.Strategies.Layers;
using Ruinum.ECS.Extensions;
using Ruinum.ECS.Scripts.Entities.Components.Game;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class RaycastFromCameraToCursorTargetStrategy : TargetStrategy
    {
        public ILayerMaskStrategy Strategy;

        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            if (Contexts.game.cameraEntity == null)
            {
                targetEntity = default;
                if (Logging) LogErrorNotFound(nameof(Contexts.game.cameraEntity), (nameof(entity), entity));
                return false;
            }
            if (!Contexts.game.cameraEntity.TryGetGameObjectComponent<Camera>(out var camera))
            {
                targetEntity = default;
                if (Logging) LogErrorNotFound(nameof(camera), (nameof(entity), entity));
                return false;
            }
            if (!Strategy.TryGet(entity, out var mask))
            {
                targetEntity = default;
                if (Logging) LogErrorNotFound(nameof(mask), (nameof(entity), entity));
                return false;
            }
            Ray ray = camera.ScreenPointToRay(new Vector2(Contexts.sharedInstance.game.services.Instance.Input.GetMouseAxisX(), Contexts.sharedInstance.game.services.Instance.Input.GetMouseAxisY()));
            if (!Physics.Raycast(ray, out var hit, Mathf.Infinity, mask, QueryTriggerInteraction.Collide))
            {
                targetEntity = default;
                if (Logging) LogErrorNotFound(nameof(ray), (nameof(entity), entity));
                return false;
            }
            if (!hit.collider.TryGetComponent<GameEntityBehaviour>(out var entityBehaviour))
            {
                targetEntity = default;
                if (Logging) LogErrorNotFound(nameof(entityBehaviour), (nameof(entity), entity));
                return false;
            }
            targetEntity = entityBehaviour.Entity;
            return true;
        }
    }
} 