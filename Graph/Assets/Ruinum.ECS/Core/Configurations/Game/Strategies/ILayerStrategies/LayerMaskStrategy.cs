using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Layers
{
    public abstract class LayerMaskStrategy : ContextInitializable, ILayerMaskStrategy
    {
        public abstract bool TryGet(GameEntity entity, out LayerMask mask);
    }
}