using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Configurations.Game.Strategies.Texts;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public sealed class StringFloatTextStrategy : TextStrategy
    {

        public IFloatValueStrategy Strategy;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public string Value = string.Empty;

        public override bool TryGet(GameEntity entity, out string text)
        {
            text = default;
            if (!Strategy.TryGet(entity, out var value))
            {
                if(Logging) LogErrorNotFound("TextComponent", (nameof(entity), entity), (nameof(Strategy), Strategy));
                return false;
            }

            text = Value + value;
            return true;
        }
    }
}