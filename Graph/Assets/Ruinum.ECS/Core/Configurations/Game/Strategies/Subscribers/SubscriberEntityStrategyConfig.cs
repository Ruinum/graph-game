using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers
{
    [CreateAssetMenu(menuName = MenuName, fileName = FileName)]
    public sealed class SubscriberEntityStrategyConfig : InitializableSerializedConfig, ISubscriberEntityStrategy
    {
        public const string MenuName = EditorConstants.EntityStrategyMenuPath + FileName;
        public const string FileName = nameof(SubscriberEntityStrategyConfig);

        [HideLabel] public ISubscriberEntityStrategy Strategy;

        public bool Process(GameEntity publisher, GameEntity subscriber)
        {
            return Strategy.Process(publisher, subscriber);
        }
    }
}