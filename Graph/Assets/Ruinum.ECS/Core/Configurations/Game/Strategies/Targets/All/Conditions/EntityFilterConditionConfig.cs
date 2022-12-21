using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Conditions
{
    [CreateAssetMenu(menuName = MenuName, fileName = FileName)]
    public sealed class EntityFilterConditionConfig : InitializableSerializedConfig, IEntityFilterCondition
    {
        public const string MenuName = EditorConstants.ConditionMenuPath + FileName;
        public const string FileName = nameof(EntityFilterConditionConfig);

        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IEntityFilterCondition Condition;

        public bool IsConditionTrue(GameEntity entity, GameEntity target)
        {
            return Condition.IsConditionTrue(entity, target);
        }
    }
}