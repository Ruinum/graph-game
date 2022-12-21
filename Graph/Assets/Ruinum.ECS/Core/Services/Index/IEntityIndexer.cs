using System.Collections.Generic;

namespace Ruinum.ECS.Services.Index
{
    public interface IEntityIndexer<TEntity, TKey>
    {
        public bool TryGetEntity(TKey key, out TEntity result);
        public bool TryGetEntities(TKey key, out HashSet<TEntity> result);
    }
}