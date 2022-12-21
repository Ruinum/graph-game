using Ruinum.ECS.Components.Indices;

public partial class Contexts
{
    public const string OwnerConfigIndex = "OwnerConfigIndex";
    public const string IdentityIndex = "IdentityIndex";
    public const string EntityTypeIndex = "EntityTypeIndex";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void OnInitializeEntityIndices()
    {
        game.AddEntityIndex(new GameIdentityIndex(game));
    }
}