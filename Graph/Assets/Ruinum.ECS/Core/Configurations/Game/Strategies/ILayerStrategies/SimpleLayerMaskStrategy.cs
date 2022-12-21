using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Layers
{
    public sealed class SimpleLayerMaskStrategy : LayerMaskStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public LayerMask Layer;

        public override bool TryGet(GameEntity entity, out LayerMask mask)
        {
            mask = Layer;
            return true;
        }
    }
}