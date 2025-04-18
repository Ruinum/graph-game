//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BeforeMovementStrategyCreateComponent beforeMovementStrategyCreate { get { return (BeforeMovementStrategyCreateComponent)GetComponent(GameComponentsLookup.BeforeMovementStrategyCreate); } }
    public bool hasBeforeMovementStrategyCreate { get { return HasComponent(GameComponentsLookup.BeforeMovementStrategyCreate); } }

    public void AddBeforeMovementStrategyCreate(Ruinum.ECS.Configurations.Game.Strategies.IEntityStrategy newStrategy) {
        var index = GameComponentsLookup.BeforeMovementStrategyCreate;
        var component = (BeforeMovementStrategyCreateComponent)CreateComponent(index, typeof(BeforeMovementStrategyCreateComponent));
        component.Strategy = newStrategy;
        AddComponent(index, component);
    }

    public void ReplaceBeforeMovementStrategyCreate(Ruinum.ECS.Configurations.Game.Strategies.IEntityStrategy newStrategy) {
        var index = GameComponentsLookup.BeforeMovementStrategyCreate;
        var component = (BeforeMovementStrategyCreateComponent)CreateComponent(index, typeof(BeforeMovementStrategyCreateComponent));
        component.Strategy = newStrategy;
        ReplaceComponent(index, component);
    }

    public void RemoveBeforeMovementStrategyCreate() {
        RemoveComponent(GameComponentsLookup.BeforeMovementStrategyCreate);
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

    static Entitas.IMatcher<GameEntity> _matcherBeforeMovementStrategyCreate;

    public static Entitas.IMatcher<GameEntity> BeforeMovementStrategyCreate {
        get {
            if (_matcherBeforeMovementStrategyCreate == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BeforeMovementStrategyCreate);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBeforeMovementStrategyCreate = matcher;
            }

            return _matcherBeforeMovementStrategyCreate;
        }
    }
}
