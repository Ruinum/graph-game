using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Utility.Native;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class AccelerationByVelocityTimeValueStrategy : FloatValueBaseStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy VelocityStart;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy VelocityEnd;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public IFloatValueStrategy Time;

        public override bool TryGet(GameEntity entity, out float value)
        {
            if (!VelocityStart.TryGet(entity, out var velocityStart))
            {
                value = default;
                if(Logging) LogErrorNotFound(nameof(velocityStart), (nameof(entity), entity));
                return false;
            }

            if (!VelocityEnd.TryGet(entity, out var velocityEnd))
            {
                value = default;
                if(Logging) LogErrorNotFound(nameof(velocityEnd), (nameof(entity), entity), (nameof(velocityStart), velocityStart));
                return false;
            }

            if (!Time.TryGet(entity, out var time))
            {
                value = default;
                if(Logging) LogErrorNotFound(nameof(time), (nameof(entity), entity), (nameof(velocityStart), velocityStart), (nameof(velocityEnd), velocityEnd));
                return false;
            }

            value = (velocityEnd - velocityStart) / MathUtility.ClampZero(time);
            return true;
        }
    }
}