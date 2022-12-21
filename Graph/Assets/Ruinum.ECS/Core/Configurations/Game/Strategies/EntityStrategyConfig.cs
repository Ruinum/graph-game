using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    [CreateAssetMenu(menuName = MenuName, fileName = FileName)]
    public sealed class EntityStrategyConfig : InitializableSerializedConfig, IEntityStrategy
    {
        public const string MenuName = Ruinum.ECS.Constants.EditorConstants.EntityStrategyMenuPath + FileName;
        public const string FileName = nameof(EntityStrategyConfig);

        [AssetSelector(Filter = "t:EntityStrategyConfig"), HideLabel] public IEntityStrategy Strategy;
        
        public bool Process(GameEntity entity)
        {
            return Strategy.Process(entity);
        }           
    }
}