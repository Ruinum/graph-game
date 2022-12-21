using Ruinum.ECS.Constants;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    [CreateAssetMenu(menuName = MenuName, fileName = FileName)]
    public sealed class FloatValueStrategyConfig : InitializableSerializedConfig, IFloatValueStrategy
    {
        public const string MenuName = EditorConstants.EntityStrategyMenuPath + FileName;
        public const string FileName = nameof(FloatValueStrategyConfig);

        public IFloatValueStrategy Strategy;

        public bool TryGet(GameEntity entity, out float value)
        {
            return Strategy.TryGet(entity, out value);
        }
    }
}