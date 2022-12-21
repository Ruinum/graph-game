using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class AbsoluteValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IFloatValueStrategy Strategy;

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!Strategy.TryGet(entity, out var result))
            {
                value = default;
                if(Logging) LogErrorNotFound(nameof(result), (nameof(entity), entity));
                return false;
            }

            value = Mathf.Abs(result);
            return true;
        }
    }
}