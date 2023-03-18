using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Texts
{
    public sealed class TextFromComponentStrategy : TextStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target = new CurrentEntityTargetStrategy();

        public override bool TryGet(GameEntity entity, out string text)
        {
            if (!Target.TryGet(entity, out var target))
            {
                text = default;
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!target.hasText)
            {
                text = default;
                if(Logging) LogErrorNotFound("TextComponent", (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            text = target.text.Value;
            return true;
        }
    }
}