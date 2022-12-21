//using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class VectorAxisValueStrategy : FloatValueBaseStrategy
    {
        //[LabelWidth(EditorConstants.SmallLabelWidth)] public Vector3Axis Axis;
        //[LabelWidth(EditorConstants.SmallLabelWidth)] public VectorStrategy Vector;

        public override bool TryGet(GameEntity entity, out float value)
        {
            value = default;
            //if (!Vector.TryGet(entity, out var vector))
            //{
            //    value = default;
            //    if(Logging) LogErrorNotFound(nameof(vector), (nameof(entity), entity));
            //    return false;
            //}

            //value = VectorUtilities.GetAxisValue(Axis, vector);
            return true;
        }
    }
}