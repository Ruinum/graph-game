using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Layers
{
    public interface ILayerMaskStrategy 
    {
        bool TryGet(GameEntity entity, out LayerMask mask);
    }
}