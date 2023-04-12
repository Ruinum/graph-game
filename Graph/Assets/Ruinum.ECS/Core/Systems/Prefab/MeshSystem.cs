using Entitas;
using Ruinum.ECS.Core.Extensions.Unity;
using Ruinum.ECS.Integration.Entitas;
using Ruinum.ECS.Services;
using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSystem : ReactiveSystemExtended<GameEntity>
{
    private readonly IAssetService _assetService;
    public MeshSystem(IContext<GameEntity> context, IAssetService assetService) : base(context)
    {
        _assetService = assetService;
    }
    protected override void Execute(GameEntity entity)
    {
        var gameObject = entity.gameObject.Value;
        if(gameObject.IsNull()) 
        {
            return;
        }

        var component = gameObject.GetComponent<MeshComponentBehaviour>();
        if(component.IsNull()) 
        {
            return;
        }

        var mesh = entity.mesh.Reference;
        if (mesh == null || !mesh.RuntimeKeyIsValid())
        {
            return;
        }

        if(!_assetService.TryGetAsset(mesh, out GameObject asset))
        {
            return;
        }

        if (entity.hasMeshGameObject)
        {
            var meshGameObject = entity.meshGameObject.Value;
            if (!meshGameObject.IsNull()) 
            {
                Object.Destroy(meshGameObject);
            }
        }

        entity.ReplaceMeshGameObject(Object.Instantiate(asset, component.Mesh.transform, false));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMesh && entity.hasGameObject;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Mesh);
    }
}
