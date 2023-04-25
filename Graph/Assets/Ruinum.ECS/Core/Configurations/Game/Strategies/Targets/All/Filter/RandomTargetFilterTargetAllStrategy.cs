using System.Collections.Generic;
using UnityEngine;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Filter
{
    public sealed class RandomTargetFilterTargetAllStrategy : FilterTargetAllStrategy
    {
        public override bool TryGet(GameEntity entity, List<GameEntity> sourceBuffer, List<GameEntity> resultBuffer)
        {
            if (sourceBuffer.Count == 0) 
            { 
                resultBuffer = default;
                return false; 
            }

            resultBuffer.Add(sourceBuffer[Random.Range(0, sourceBuffer.Count)]);        
            return true;
        }
    }
}