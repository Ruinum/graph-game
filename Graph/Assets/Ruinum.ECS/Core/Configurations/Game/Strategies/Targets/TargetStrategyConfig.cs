using Ruinum.ECS.Constants;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    [CreateAssetMenu(menuName = EditorConstants.EntityStrategyMenuPath + nameof(TargetStrategyConfig), fileName = nameof(TargetStrategyConfig))]
    public sealed class TargetStrategyConfig : InitializableSerializedConfig, ITargetStrategy
    {
        public ITargetStrategy Target;

        public bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            return Target.TryGet(entity, out targetEntity);
        }
    }
}