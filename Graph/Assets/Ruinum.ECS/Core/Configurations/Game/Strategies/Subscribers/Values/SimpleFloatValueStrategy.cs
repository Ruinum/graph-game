using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class SimpleFloatValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public float Value;

        public override bool TryGet(GameEntity entity, out float value)
        {
            value = Value;
            return true;
        }
    }
}