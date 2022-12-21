using Ruinum.ECS.Configurations;
using System.Collections.Generic;


namespace Ruinum.ECS.Services.Interfaces
{
    public interface IEntityIndexService
    {
        public bool TryGetTarget(GameEntity rootOwner, EntityConfig config, out GameEntity target);

        public bool TryGetTargets(GameEntity rootOwner, EntityConfig config, out HashSet<GameEntity> target);
    }
}