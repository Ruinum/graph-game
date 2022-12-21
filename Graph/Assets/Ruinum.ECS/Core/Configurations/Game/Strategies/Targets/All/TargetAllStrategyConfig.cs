using System.Collections.Generic;
using Ruinum.ECS.Constants;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    [CreateAssetMenu(menuName = MenuName, fileName = FileName)]
    public sealed class TargetAllStrategyConfig : InitializableSerializedConfig, ITargetAllStrategy
    {
        public const string MenuName = EditorConstants.EntityStrategyMenuPath + FileName;
        public const string FileName = nameof(TargetAllStrategyConfig);

        public ITargetAllStrategy Strategy;

        public bool TryGet(GameEntity entity, List<GameEntity> buffer)
        {
            return Strategy.TryGet(entity, buffer);
        }
    }
}