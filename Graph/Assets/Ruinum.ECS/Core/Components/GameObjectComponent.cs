using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public sealed class GameObjectComponent : IComponent
{
    [EntityIndex] public GameObject Value;
}