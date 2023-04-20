using Ruinum.ECS.Attributes;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;
using UnityEngine.AddressableAssets;

namespace Ruinum.ECS.Configurations.Game.Strategies.Mesh
{
    public sealed class SimpleMeshStrategy : MeshStrategy
    {
        [AssetReferenceField, HideReferenceObjectPicker, LabelWidth(EditorConstants.SmallLabelWidth)] public AssetReferenceGameObject Reference;

        public override bool TryGet(GameEntity entity, out AssetReferenceGameObject result)
        {
            result = Reference;
            return true;
        }
    }
}