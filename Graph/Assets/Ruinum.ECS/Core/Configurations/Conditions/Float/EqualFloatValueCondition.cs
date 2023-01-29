using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Conditions.Entities.Float
{
    public sealed class EqualFloatValueCondition : FloatValueCondition
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy TargetValue;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public EqualityType Equality;

        protected override bool IsTrue(GameEntity entity, float value)
        {
            if (!TargetValue.TryGet(entity, out var targetValue))
            {
                if(Logging) LogErrorNotFound(nameof(targetValue), (nameof(entity), entity));
                return false;
            }
            return ConditionUtilities.IsConditionTrue(Equality, targetValue, value);           
        }
    }
}