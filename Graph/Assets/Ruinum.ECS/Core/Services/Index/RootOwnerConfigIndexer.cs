using System.Collections.Generic;
using Entitas;

namespace Ruinum.ECS.Services.Index
{
    //public sealed class RootOwnerConfigIndexer : EntityIndexer<GameEntity, RootOwnerConfigIndexer.Key>
    //{
    //    public RootOwnerConfigIndexer(IContext<GameEntity> context) : base(context, GameMatcher.OwnerEntityConfigIndexKey, KeyEqualityComparer.Comparer)
    //    {
    //    }
        
    //    public struct Key
    //    {
    //        public GameEntity Entity;
    //        public int ConfigIndex;
    //    }

    //    private class KeyEqualityComparer : IEqualityComparer<Key>
    //    {
    //        public static readonly IEqualityComparer<Key> Comparer = new KeyEqualityComparer();

    //        public bool Equals(Key x, Key y)
    //        {
    //            return x.Entity.creationIndex.Equals(y.Entity.creationIndex) && x.ConfigIndex.Equals(y.ConfigIndex);
    //        }

    //        public int GetHashCode(Key obj)
    //        {
    //            unchecked
    //            {
    //                return (obj.Entity.creationIndex * 397) ^ obj.ConfigIndex;
    //            }
    //        }
    //    }
    //}
}