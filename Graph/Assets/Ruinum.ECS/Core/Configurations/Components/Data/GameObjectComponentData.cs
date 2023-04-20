using Sirenix.OdinInspector;
using UnityEngine.AddressableAssets;

public sealed class GameObjectComponentData : IComponentData
{
    [HideReferenceObjectPicker, HideLabel, AssetsOnly] public AssetReferenceGameObject Reference;
}