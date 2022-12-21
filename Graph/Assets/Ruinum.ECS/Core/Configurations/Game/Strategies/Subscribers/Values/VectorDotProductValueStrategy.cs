//using Ruinum.ECS.Configurations.Game.Strategies.VectorStrategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class VectorDotProductValueStrategy : FloatValueBaseStrategy
    {
        //[LabelWidth(EditorConstants.SmallLabelWidth)] public IVectorStrategy First = new SimpleVectorStrategy();
        //[LabelWidth(EditorConstants.SmallLabelWidth)] public IVectorStrategy Second = new SimpleVectorStrategy();
        
        public override bool TryGet(GameEntity entity, out float value)
        {
            value = default;
            //if (!First.TryGet(entity, out var fist))
            //{
            //    value = default;
            //    if(Logging) LogErrorNotFound(nameof(fist), (nameof(entity), entity));
            //    return false;
            //}

            //if (!Second.TryGet(entity, out var second))
            //{
            //    value = default;
            //    if(Logging) LogErrorNotFound(nameof(second), (nameof(entity), entity), (nameof(fist), fist));
            //    return false;
            //}

            //value = Vector3.Dot(fist, second);
            return true;
        }
    }
}