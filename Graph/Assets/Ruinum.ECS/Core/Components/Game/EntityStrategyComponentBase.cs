using Entitas;
using Ruinum.ECS.Configurations.Game.Strategies;
using Sirenix.OdinInspector;

public abstract class EntityStrategyComponentBase : IComponent
{
    [HideLabel] [AssetSelector(Filter = "t:EntityStrategyConfig")] public IEntityStrategy Strategy;
}