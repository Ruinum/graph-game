using Entitas.CodeGeneration.Attributes;
using UnityEngine.AddressableAssets;

[System.Serializable][EditorComponent][Game][Event(EventTarget.Self)]
public sealed class MeshComponent : ResourceComponent<AssetReferenceGameObject>
{
}