using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Texts
{
    public sealed class TextEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITextStrategy Strategy;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!Strategy.TryGet(entity, out var text))
            {
                if(Logging) LogErrorNotFound(nameof(text), (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            target.ReplaceText(text);
            return true;
        }
    }
}
