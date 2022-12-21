using System.Collections.Generic;
using Entitas;
using Ruinum.ECS.Extensions;

namespace Ruinum.ECS.Services.Index
{
    public abstract class EntityIndexer<TEntity, TKey> : IEntityIndexer<TEntity, TKey> where TEntity : class, IEntity
    {
        private static Dictionary<TKey, EntitySet> _index;

        protected EntityIndexer(IContext<TEntity> context, IMatcher<TEntity> matcher, IEqualityComparer<TKey> comparer)
        {
            var group = context.GetGroup(matcher);
            group.OnEntityAdded += GroupOnOnEntityAdded;
            group.OnEntityRemoved += EntityOnOnComponentRemoved;
            _index = new Dictionary<TKey, EntitySet>(comparer);
        }
        
        private static bool TryGetEntities(TKey key, out EntitySet result)
        {
            if (!_index.TryGetValue(key, out var set) || set.Set.Count == 0)
            {
                result = default;
                return false;
            }

            result = set;
            return true;
        }
        
        private void GroupOnOnEntityAdded(IGroup<TEntity> @group, TEntity entity, int index, IComponent component)
        {
            var key = ((ValueComponent<TKey>) component).Value;
            if (!_index.TryGetValue(key, out var set))
            {
                set = new EntitySet {Set = new HashSet<TEntity>(EntityEqualityComparer<TEntity>.comparer)};
                _index[key] = set;
            }
            set.Last = entity;
            set.Set.Add(entity);
            entity.Retain(this);
        }

        private void EntityOnOnComponentRemoved(IGroup<TEntity> @group, TEntity entity, int index, IComponent component)
        {
            entity.Release(this);
            var set = _index[((ValueComponent<TKey>) component).Value];
            set.Set.Remove(entity);
            if (set.Last == entity && set.Set.TryGetFirst(out var last))
            {
                set.Last = last;
            }
        }

        public bool TryGetEntity(TKey key, out TEntity result)
        {
            if (!TryGetEntities(key, out EntitySet set))
            {
                result = default;
                return false;
            }
            result = set.Last;
            return true;
        }
        
        public bool TryGetEntities(TKey key, out HashSet<TEntity> result)
        {
            if (!TryGetEntities(key, out EntitySet set))
            {
                result = default;
                return false;
            }
            result = set.Set;
            return true;
        }

        private sealed class EntitySet
        {
            public TEntity Last;
            public HashSet<TEntity> Set;
        }
    }
}