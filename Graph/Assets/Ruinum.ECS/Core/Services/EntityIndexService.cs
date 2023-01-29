using System.Collections.Generic;
using Ruinum.ECS.Configurations;
using Ruinum.ECS.Configurations.Game.Indexes;
using Ruinum.ECS.Services.Index;
using Ruinum.ECS.Services.Interfaces;
using UnityEngine;

namespace Ruinum.ECS.Services
{
    public sealed class EntityIndexService : IEntityIndexService
    {
        private readonly RootOwnerConfigIndexer _rootOwnerConfigIndex;
        private readonly RootOwnerEntityTypeIndexer _rootOwnerEntityType;
        private RootOwnerConfigIndexer.Key _rootOwnerConfigKeyBuffer;
        private RootOwnerEntityTypeIndexer.Key _rootOwnerEntityTypeKeyBuffer;

        public EntityIndexService(Contexts context)
        {
            _rootOwnerConfigIndex = new RootOwnerConfigIndexer(context.game);
            _rootOwnerEntityType = new RootOwnerEntityTypeIndexer(context.game);
        }

        public bool TryGetTarget(GameEntity rootOwner, EntityConfig config, out GameEntity target)
        {
            if (rootOwner.HasConfigIndexCached && config.ConfigIndex == rootOwner.ConfigIndexCached)
            {
                target = rootOwner;
                return true;
            }

            _rootOwnerConfigKeyBuffer.Entity = rootOwner;
            _rootOwnerConfigKeyBuffer.ConfigIndex = config.ConfigIndex;
            var result = _rootOwnerConfigIndex.TryGetEntity(_rootOwnerConfigKeyBuffer, out target);
            if (target != null && config.ConfigIndex != target.ConfigIndexCached)
            {
                Debug.LogError("ERROR OwnerEntityConfigIndex config: " + config.name + " target: " + target);
            }
            return result;
        }

        public bool TryGetTargets(GameEntity rootOwner, EntityConfig config, out HashSet<GameEntity> target)
        {
            _rootOwnerConfigKeyBuffer.Entity = rootOwner;
            _rootOwnerConfigKeyBuffer.ConfigIndex = config.ConfigIndex;
            return _rootOwnerConfigIndex.TryGetEntities(_rootOwnerConfigKeyBuffer, out target);
        }

        public bool TryGetTarget(GameEntity rootOwner, EntityTypeConfig config, out GameEntity target)
        {
            if (rootOwner.hasEntityType && config == rootOwner.entityType.Value)
            {
                target = rootOwner;
                return true;
            }
            _rootOwnerEntityTypeKeyBuffer.Entity = rootOwner;
            _rootOwnerEntityTypeKeyBuffer.Config = config;
            return _rootOwnerEntityType.TryGetEntity(_rootOwnerEntityTypeKeyBuffer, out target);
        }

        public bool TryGetTargets(GameEntity rootOwner, EntityTypeConfig config, out HashSet<GameEntity> target)
        {
            _rootOwnerEntityTypeKeyBuffer.Entity = rootOwner;
            _rootOwnerEntityTypeKeyBuffer.Config = config;
            return _rootOwnerEntityType.TryGetEntities(_rootOwnerEntityTypeKeyBuffer, out target);
        }
    }
}