using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Extensions.Native;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class FloatValueEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target;
        [LabelWidth(EditorConstants.SmallLabelWidth), AssetSelector(Filter = "t:FloatValueStrategyConfig")] public IFloatValueStrategy Strategy;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public bool CheckEquality = false;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!Strategy.TryGet(entity, out var value))
            {
                if(Logging) LogErrorNotFound(nameof(value), (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            if (CheckEquality && target.hasFloatValue && target.floatValue.Value.IsEqual(value))
            {
                if(Logging) LogError($"CheckEquality is false or Target FloatValueComponent missing or {nameof(target.floatValue.Value)} is not equal {nameof(value)}.", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            target.ReplaceFloatValue(value);
            return true;
        }
    }
}