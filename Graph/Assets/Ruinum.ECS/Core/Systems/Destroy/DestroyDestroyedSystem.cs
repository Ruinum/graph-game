using System.Collections.Generic;
using Entitas;

namespace Ruinum.ECS.Systems.Destroy
{
    public sealed class DestroyDestroyedSystem : ICleanupSystem {

        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new List<GameEntity>();

        public DestroyDestroyedSystem(Contexts contexts) {
            _group = contexts.game.GetGroup(GameMatcher.Destroyed);
        }

        public void Cleanup()
        {
            if (_group.count == 0)
            {
                return;
            }
            _group.GetEntities(_buffer);
            for (int i = 0; i < _buffer.Count; i++)
            {
                var entity = _buffer[i];
                entity.ClearOwners();
                entity.Destroy();
            }
        }
    }
}