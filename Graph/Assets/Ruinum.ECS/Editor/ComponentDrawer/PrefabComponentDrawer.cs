
using Ruinum.ECS.Assets;
using Ruinum.ECS.Scripts.Entities.Components.Game;

namespace Ruinum.ECS.Editor.ComponentDrawer
{
    public sealed class PrefabComponentDrawer : ResourceComponentDrawer<PrefabComponent, GameEntityBehaviour, ComponentReference<GameEntityBehaviour>>
    {
        protected override string FieldLabel => "Prefab";
    }
}