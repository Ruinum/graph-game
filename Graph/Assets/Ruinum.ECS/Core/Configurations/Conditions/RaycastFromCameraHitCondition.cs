using Ruinum.ECS.Configurations.Game.Strategies.Layers;
using Ruinum.ECS.Extensions;
using UnityEngine;

namespace Ruinum.ECS.Core.Conditions
{
    public class RaycastFromCameraHitCondition : EntityCondition
    {
        public ILayerMaskStrategy Strategy;

        protected override bool IsTrue(GameEntity entity)
        {
            if (Contexts.game.cameraEntity == null)
            {
                if (Logging) LogErrorNotFound(nameof(Contexts.game.cameraEntity), (nameof(entity), entity));
                return false;
            }

            if (!Contexts.game.cameraEntity.TryGetGameObjectComponent<Camera>(out var camera))
            {
                if (Logging) LogErrorNotFound(nameof(camera), (nameof(entity), entity));
                return false;
            }

            if (!Strategy.TryGet(entity, out var mask))
            {
                if (Logging) LogErrorNotFound(nameof(mask), (nameof(entity), entity));
                return false;
            }

            Ray ray = camera.ScreenPointToRay(new Vector2(Contexts.sharedInstance.game.services.Instance.Input.GetMouseAxisX(), Contexts.sharedInstance.game.services.Instance.Input.GetMouseAxisY()));
            if (!Physics.Raycast(ray, out var hit, Mathf.Infinity, mask, QueryTriggerInteraction.Collide))
            {
                if (Logging) LogErrorNotFound(nameof(ray), (nameof(entity), entity));
                return false;
            }

            return true;
        }
    }
}