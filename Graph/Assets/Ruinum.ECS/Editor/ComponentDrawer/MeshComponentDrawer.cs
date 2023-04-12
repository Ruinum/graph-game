using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Ruinum.ECS.Editor.ComponentDrawer
{
    public sealed class MeshComponentDrawer : ResourceComponentDrawer<MeshComponent, GameObject, AssetReferenceGameObject>
    {
        protected override string FieldLabel => "Prefab";
    }
}