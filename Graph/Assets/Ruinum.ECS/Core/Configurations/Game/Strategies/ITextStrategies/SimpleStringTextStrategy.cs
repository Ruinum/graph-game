using Ruinum.ECS.Configurations.Game.Strategies.Texts;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public sealed class SimpleStringTextStrategy : TextStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public string Value = string.Empty;

        public override bool TryGet(GameEntity entity, out string result)
        {
            result = Value;
            return true;
        }
    }
}