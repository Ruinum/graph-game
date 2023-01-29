using Sirenix.OdinInspector;
using UnityEngine;


public sealed class GameObjectComponentData : IComponentData
{
    [HideReferenceObjectPicker, HideLabel, AssetsOnly] public GameObject Reference;
}