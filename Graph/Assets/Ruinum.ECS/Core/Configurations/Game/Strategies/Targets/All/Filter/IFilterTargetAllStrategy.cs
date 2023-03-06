using System.Collections.Generic;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Filter
{
    public interface IFilterTargetAllStrategy 
    {
        bool TryGet(GameEntity entity, List<GameEntity> sourceBuffer, List<GameEntity> resultBuffer);
    }
}