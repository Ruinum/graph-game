using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Core.Conditions
{
    public class FloatValueEqualCondition : EntityCondition
    {
        [AssetSelector(Filter = "t:FloatValueStrategyConfig"), LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy FirstFloat;
        [AssetSelector(Filter = "t:FloatValueStrategyConfig"), LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy SecondFloat;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public EqualityType Equality;

        protected override bool IsTrue(GameEntity entity)
        {

            if (!FirstFloat.TryGet(entity, out var first))
            {
                if (Logging) LogErrorNotFound(nameof(first), (nameof(entity), entity));
                return false;
            }
            if (!SecondFloat.TryGet(entity, out var second))
            {
                if (Logging) LogErrorNotFound(nameof(second), (nameof(entity), entity), (nameof(first), first));
                return false;
            }
            return ConditionUtilities.IsConditionTrue(Equality, first, second);
        }
    }
}