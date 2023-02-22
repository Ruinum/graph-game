using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Conditions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Conditions.Entities
{
    public sealed class EntityListContainsElementsCondition : EntityCondition
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target = new CurrentEntityTargetStrategy();

        protected override bool IsTrue(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if (Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            return target.hasEntityList && target.entityList.Value.Count > 0;
        }
    }
    
    public sealed class EntityListContainsMemberCondition : EntityCondition
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy List = new CurrentEntityTargetStrategy();
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target = new CurrentEntityTargetStrategy();

        protected override bool IsTrue(GameEntity entity)
        {
            if (!List.TryGet(entity, out var listEntity))
            {
                if(Logging) LogErrorNotFound(nameof(listEntity), (nameof(entity), entity));
                return false;
            }
            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity), (nameof(listEntity), listEntity));
                return false;
            }
            return listEntity.hasEntityList && listEntity.entityList.Value.Contains(target);
        }
    }
}