using System.Collections.Generic;
using Ruinum.ECS.Configurations;
using Ruinum.ECS.Services.Index;
using Ruinum.ECS.Services.Interfaces;
using UnityEngine;

namespace Ruinum.ECS.Services
{
    public sealed class EntityIndexService : IEntityIndexService
    {
        //private readonly RootOwnerConfigIndexer _rootOwnerConfigIndex;
        //private RootOwnerConfigIndexer.Key _rootOwnerConfigKeyBuffer;
        
        //public EntityIndexService(Contexts context)
        //{
        //    _rootOwnerConfigIndex = new RootOwnerConfigIndexer(context.game);
        //}
        
        public bool TryGetTarget(GameEntity rootOwner, EntityConfig config, out GameEntity target)
        {
            if (rootOwner.HasConfigIndexCached && config.ConfigIndex == rootOwner.ConfigIndexCached)
            {
                target = rootOwner;
                return true;
            }

            target = default;

            //_rootOwnerConfigKeyBuffer.Entity = rootOwner;
            //_rootOwnerConfigKeyBuffer.ConfigIndex = config.ConfigIndex;
            //var result = _rootOwnerConfigIndex.TryGetEntity(_rootOwnerConfigKeyBuffer, out target);
            //if (target!= null && config.ConfigIndex != target.ConfigIndexCached)
            //{
            //    Debug.LogError("ERROR OwnerEntityConfigIndex config: " + config.name + " target: " + target) ;
            //}
            //return result;

            return false;
        }
        
        public bool TryGetTargets(GameEntity rootOwner, EntityConfig config, out HashSet<GameEntity> target)
        {
            target = default;
            //_rootOwnerConfigKeyBuffer.Entity = rootOwner;
            //_rootOwnerConfigKeyBuffer.ConfigIndex = config.ConfigIndex;
            //return _rootOwnerConfigIndex.TryGetEntities(_rootOwnerConfigKeyBuffer, out target);

            return false;
        }
    }
}