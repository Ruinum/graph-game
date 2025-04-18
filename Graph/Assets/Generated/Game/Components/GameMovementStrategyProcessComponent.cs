//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MovementStrategyProcessComponent movementStrategyProcess { get { return (MovementStrategyProcessComponent)GetComponent(GameComponentsLookup.MovementStrategyProcess); } }
    public bool hasMovementStrategyProcess { get { return HasComponent(GameComponentsLookup.MovementStrategyProcess); } }

    public void AddMovementStrategyProcess(Ruinum.ECS.Configurations.Game.Strategies.IEntityStrategy newStrategy) {
        var index = GameComponentsLookup.MovementStrategyProcess;
        var component = (MovementStrategyProcessComponent)CreateComponent(index, typeof(MovementStrategyProcessComponent));
        component.Strategy = newStrategy;
        AddComponent(index, component);
    }

    public void ReplaceMovementStrategyProcess(Ruinum.ECS.Configurations.Game.Strategies.IEntityStrategy newStrategy) {
        var index = GameComponentsLookup.MovementStrategyProcess;
        var component = (MovementStrategyProcessComponent)CreateComponent(index, typeof(MovementStrategyProcessComponent));
        component.Strategy = newStrategy;
        ReplaceComponent(index, component);
    }

    public void RemoveMovementStrategyProcess() {
        RemoveComponent(GameComponentsLookup.MovementStrategyProcess);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMovementStrategyProcess;

    public static Entitas.IMatcher<GameEntity> MovementStrategyProcess {
        get {
            if (_matcherMovementStrategyProcess == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MovementStrategyProcess);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMovementStrategyProcess = matcher;
            }

            return _matcherMovementStrategyProcess;
        }
    }
}
