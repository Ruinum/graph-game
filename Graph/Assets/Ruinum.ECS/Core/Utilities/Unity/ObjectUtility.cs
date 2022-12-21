using UnityEngine;

namespace Ruinum.ECS.Core.Utility.Unity
{
    public static class ObjectUtility
    {
        public static bool IsNull(Object source)
        {
            return source == null || source.Equals(null);
        }
    }
}