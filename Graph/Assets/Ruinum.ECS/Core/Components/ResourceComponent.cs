using Entitas;

using Ruinum.ECS.Attributes;
using Ruinum.ECS.Configurations.Components.Data;

using Sirenix.OdinInspector;
using UnityEngine.AddressableAssets;


public abstract class ResourceComponent : IComponent, IComponentData
{
#if UNITY_EDITOR
    public abstract void SetReference(AssetReference reference);
#endif
}

public abstract class ResourceComponent<T> : ResourceComponent where T : AssetReference
{
    [AssetReferenceField, HideReferenceObjectPicker] public T Reference;

#if UNITY_EDITOR
    public override void SetReference(AssetReference reference)
    {
        if (reference != null)
        {
            Reference = (T)reference;
        }
    }
#endif
}