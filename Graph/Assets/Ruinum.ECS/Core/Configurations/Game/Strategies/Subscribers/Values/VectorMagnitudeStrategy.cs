//using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class VectorMagnitudeStrategy : FloatValueBaseStrategy
    {
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

            //value = vector.magnitude;
            return true;
        }
    }
}