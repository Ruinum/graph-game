using Ruinum.ECS.Core.Utility.Unity;
using UnityEngine;


namespace Ruinum.ECS.Core.Extensions.Unity
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this Object source)
        {
            return ObjectUtility.IsNull(source);
        }
    }
}