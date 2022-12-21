//using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class VectorLengthValueStrategy : FloatValueBaseStrategy
    {
        //[LabelWidth(EditorConstants.LargeLabelWidth)] public IVectorStrategy Vector;

        public override bool TryGet(GameEntity entity, out float value)
        {
            value = default;
            //if (!Vector.TryGet(entity, out var vector))
            //{
            //    if(Logging) LogErrorNotFound(nameof(vector), (nameof(entity), entity));
            //    value = default;
            //    return false;
            //}
            //value = vector.magnitude;
            return true;
        }
    }
}