using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using UnityEngine;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class SceneConfigComponentStrategy : ContextInitializable, ISceneConfigStrategy
    {
        public ITargetStrategy Target;

        public bool TryGet(GameEntity entity, out SceneConfig result)
        {
            result = default;

            if (!Target.TryGet(entity, out var targetEntity))
            {
                if (Logging)
                {
                    LogErrorNotFound(nameof(targetEntity), (nameof(entity), entity));
                }
                return false;
            }

            if (!targetEntity.hasSceneConfig)
            {
                if (Logging)
                {
                    LogErrorNotFound(nameof(SceneConfig), (nameof(targetEntity), targetEntity));
                }
                return false;
            }

            result = targetEntity.sceneConfig.Value;

            return true;
        }
    }
}