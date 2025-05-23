//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public StrategyCreateComponent strategyCreate { get { return (StrategyCreateComponent)GetComponent(GameComponentsLookup.StrategyCreate); } }
    public bool hasStrategyCreate { get { return HasComponent(GameComponentsLookup.StrategyCreate); } }

    public void AddStrategyCreate(Ruinum.ECS.Configurations.Game.Strategies.IEntityStrategy newStrategy) {
        var index = GameComponentsLookup.StrategyCreate;
        var component = (StrategyCreateComponent)CreateComponent(index, typeof(StrategyCreateComponent));
        component.Strategy = newStrategy;
        AddComponent(index, component);
    }

    public void ReplaceStrategyCreate(Ruinum.ECS.Configurations.Game.Strategies.IEntityStrategy newStrategy) {
        var index = GameComponentsLookup.StrategyCreate;
        var component = (StrategyCreateComponent)CreateComponent(index, typeof(StrategyCreateComponent));
        component.Strategy = newStrategy;
        ReplaceComponent(index, component);
    }

    public void RemoveStrategyCreate() {
        RemoveComponent(GameComponentsLookup.StrategyCreate);
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

    static Entitas.IMatcher<GameEntity> _matcherStrategyCreate;

    public static Entitas.IMatcher<GameEntity> StrategyCreate {
        get {
            if (_matcherStrategyCreate == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StrategyCreate);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStrategyCreate = matcher;
            }

            return _matcherStrategyCreate;
        }
    }
}
