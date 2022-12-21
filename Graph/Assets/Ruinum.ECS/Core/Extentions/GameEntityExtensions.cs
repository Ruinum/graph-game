using System.Collections.Generic;
using UnityEngine;

namespace Ruinum.ECS.Extensions
{
    public static class GameEntityExtensions
    {
        public static Vector3 GetTransformMoveVector(this GameEntity entity)
        {
            return entity.hasTransformMoveVector ? entity.transformMoveVector.Value : Vector3.zero;
        }      
    }
}