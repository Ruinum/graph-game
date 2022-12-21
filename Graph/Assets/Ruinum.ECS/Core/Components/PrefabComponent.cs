using Ruinum.ECS.Assets;
using Ruinum.ECS.Scripts.Entities.Components.Game;

[System.Serializable][EditorComponent][Game]
public sealed class PrefabComponent : ResourceComponent<ComponentReference<GameEntityBehaviour>> { }