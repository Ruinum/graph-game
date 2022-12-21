using Ruinum.ECS.Entity.Interfaces;
using Ruinum.ECS.Extensions;
using Ruinum.Entities.Game;


public partial class GameEntity : IConfigIndexEntity, IEntityComponentCopy {
    public GameEntity OwnerEntity;

    public GameEntity RootOwnerEntity;

    public bool HasOwner = false;

    public bool HasRootOwner = false;

    public bool HasConfigIndexCached;
    public int ConfigIndexCached;

    public void ClearOwners()
    {
        OwnerEntity = null;
        RootOwnerEntity = null;
        HasOwner = false;
        HasRootOwner = false;
        HasConfigIndexCached = false;
    }

    public void SetConfigIndex(int index)
    {
        ConfigIndexCached = index;
        HasConfigIndexCached = true;
    }
    
    public void SetOwner(GameEntity owner)
    {
        OwnerEntity = owner;
        HasOwner = true;
    }

    public void SetRootOwner(GameEntity owner)
    {
        RootOwnerEntity = owner;
        HasRootOwner = true;
    }

    public override string ToString()
    {
        return HasConfigIndexCached 
            ? Contexts.sharedInstance.GetConfigService().GetConfig(ConfigIndexCached).name + " (" + creationIndex + ")"
            : base.ToString();
    }
}