using System.Collections.Generic;
using Entitas;
using Ruinum.ECS.Configurations.Game.Indexes;

namespace Ruinum.ECS.Services.Index
{
    public sealed class RootOwnerEntityTypeIndexer : EntityIndexer<GameEntity, RootOwnerEntityTypeIndexer.Key>
    {
        public RootOwnerEntityTypeIndexer(IContext<GameEntity> context) : base(context, GameMatcher.OwnerEntityTypeIndexKey, KeyEqualityComparer.Comparer)
        {
        }

        public struct Key
        {
            public GameEntity Entity;
            public EntityTypeConfig Config;
        }

        private class KeyEqualityComparer : IEqualityComparer<Key>
        {
            public static readonly IEqualityComparer<Key> Comparer = new KeyEqualityComparer();

            public bool Equals(Key x, Key y)
            {
                return x.Entity.creationIndex.Equals(y.Entity.creationIndex) && x.Config.Equals(y.Config);
            }

            public int GetHashCode(Key obj)
            {
                unchecked
                {
                    return (obj.Entity.creationIndex * 397) ^ obj.Config.GetHashCode();
                }
            }
        }
    }
}