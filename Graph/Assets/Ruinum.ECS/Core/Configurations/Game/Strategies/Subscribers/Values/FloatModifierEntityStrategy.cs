using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Extensions.Native;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class FloatModifierEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public TargetStrategy Target = new CurrentEntityTargetStrategy();
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy Strategy;
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
            
            if (CheckEquality && target.hasFloatModifier && target.floatModifier.Value.IsEqual(value))
            {
                if(Logging) LogError($"CheckEquality is false or Target FloatModifierComponent missing or {nameof(target.floatModifier.Value)} is not equal {nameof(value)}.", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            target.ReplaceFloatModifier(value);
            return true;
        }
    }
}