using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core;
using Ruinum.ECS.Core.Conditions;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace BeastHour.Configurations.Conditions.Entities.Float
{
    public sealed class FloatEqualOtherCondition : EntityCondition
    {
        [AssetSelector(Filter = "t:FloatValueStrategyConfig"), LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy FirstFloat;
        [AssetSelector(Filter = "t:FloatValueStrategyConfig"), LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy SecondFloat;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public EqualityType Equality;

        protected override bool IsTrue(GameEntity entity)
        {
            if (!FirstFloat.TryGet(entity, out var first))
            {
                if(Logging) LogErrorNotFound(nameof(first), (nameof(entity), entity));
                return false;
            }
            if (!SecondFloat.TryGet(entity, out var second))
            {
                if(Logging) LogErrorNotFound(nameof(second), (nameof(entity), entity), (nameof(first), first));
                return false;
            }
            return ConditionUtilities.IsConditionTrue(Equality, first, second);
        }
    }
}