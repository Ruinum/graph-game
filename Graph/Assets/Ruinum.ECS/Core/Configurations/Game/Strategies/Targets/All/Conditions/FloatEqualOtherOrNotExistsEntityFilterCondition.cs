using Ruinum.ECS.Configurations.Conditions;
using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Conditions
{
    public sealed class FloatEqualOtherOrNotExistsEntityFilterCondition : EntityFilterCondition
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy SourceValue;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy TargetValue;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public EqualityType Equality;

        protected override bool IsTrue(GameEntity entity, GameEntity target)
        {
            if (!SourceValue.TryGet(entity, out var sourceValue))
            {
                if(Logging) LogErrorNotFound(nameof(sourceValue), (nameof(entity), entity));
                return false;
            }

            if (!TargetValue.TryGet(target, out var targetValue))
            {
                if(Logging) LogErrorNotFound(nameof(targetValue), (nameof(entity), entity), (nameof(sourceValue), sourceValue));
                return false;
            }

            return ConditionUtilities.IsConditionTrue(Equality, targetValue, sourceValue);
        }
    }
}