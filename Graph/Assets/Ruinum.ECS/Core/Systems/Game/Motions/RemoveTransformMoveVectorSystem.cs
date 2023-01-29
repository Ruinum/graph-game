using System.Collections.Generic;
using Entitas;

namespace Ruinum.ECS.Systems.Game.Motions
{
    public sealed class RemoveTransformMoveVectorSystem : ICleanupSystem {

        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new List<GameEntity>();

        public RemoveTransformMoveVectorSystem(GameContext context) 
        {
            _group = context.GetGroup(GameMatcher.TransformMoveVector);
        }

        public void Cleanup() 
        {
            if (_group.count == 0)
            {
                return;
            }
            foreach (var e in _group.GetEntities(_buffer)) 
            {
                e.RemoveTransformMoveVector();
            }
        }
    }
}