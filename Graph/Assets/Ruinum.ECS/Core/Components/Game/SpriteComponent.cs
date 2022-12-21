using Entitas;
using Entitas.CodeGeneration.Attributes;

using Ruinum.ECS.Configurations.Components.Data;
using Ruinum.ECS.Core.Extensions.Unity;

using Sirenix.OdinInspector;
using UnityEngine;

[System.Serializable][EditorComponent][Game][Event(EventTarget.Self)]
public sealed class SpriteComponent : IComponent, IComponentData
{
    [PreviewField(Alignment = ObjectFieldAlignment.Center)] [Title("$SpriteName")] public Sprite Value;

    private string SpriteName()
    {
        return Value.IsNull() ? string.Empty : Value.name;
    }
}