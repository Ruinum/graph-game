using Ruinum.ECS.Configurations;
using Ruinum.ECS.Configurations.Game.Indexes;
using System.Collections.Generic;


namespace Ruinum.ECS.Services.Interfaces
{
    public interface IEntityIndexService
    {
        public bool TryGetTarget(GameEntity rootOwner, EntityConfig config, out GameEntity target);

        public bool TryGetTargets(GameEntity rootOwner, EntityConfig config, out HashSet<GameEntity> target);

        public bool TryGetTarget(GameEntity rootOwner, EntityTypeConfig config, out GameEntity target);

        public bool TryGetTargets(GameEntity rootOwner, EntityTypeConfig config, out HashSet<GameEntity> target);
    }
}