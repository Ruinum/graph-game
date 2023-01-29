using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Conditions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Conditions.General
{
    [CreateAssetMenu(menuName = MenuName, fileName = FileName)]
    public sealed class EntityConditionConfig : InitializableSerializedConfig, IEntityCondition
    {
        public const string MenuName = EditorConstants.ConditionMenuPath + FileName;
        public const string FileName = nameof(EntityConditionConfig);

        [HideLabel][AssetSelector(Filter = "t:EntityConditionConfig", DropdownTitle = "Select")] public IEntityCondition Condition;

        public bool IsConditionTrue(GameEntity entity)
        {
            return Condition.IsConditionTrue(entity);
        }
    }
}