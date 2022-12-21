//using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class VectorAngleValueStrategy : FloatValueBaseStrategy
    {
        //[LabelWidth(EditorConstants.SmallLabelWidth)] public bool Absolute = false;
        //[LabelWidth(EditorConstants.SmallLabelWidth), HideIf(nameof(Absolute))] public Vector3 SignAxis = Vector3.up;
        //[LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy First;
        //[LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Second;

        public override bool TryGet(GameEntity entity, out float value)
        {
            value = default;
            //if (!First.TryGet(entity, out var first))
            //{
            //    value = default;
            //    if(Logging) LogErrorNotFound(nameof(first), (nameof(entity), entity));
            //    return false;
            //}

            //if (!Second.TryGet(entity, out var second))
            //{
            //    value = default;
            //    if(Logging) LogErrorNotFound(nameof(second), (nameof(entity), entity), (nameof(first), first));
            //    return false;
            //}

            //value = Absolute ? Vector3.Angle(first, second) : Vector3.SignedAngle(first, second, SignAxis);
            return true;
        }
    }
}