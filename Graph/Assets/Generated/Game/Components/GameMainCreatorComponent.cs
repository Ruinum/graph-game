//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MainCreatorComponent mainCreatorComponent = new MainCreatorComponent();

    public bool isMainCreator {
        get { return HasComponent(GameComponentsLookup.MainCreator); }
        set {
            if (value != isMainCreator) {
                var index = GameComponentsLookup.MainCreator;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : mainCreatorComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherMainCreator;

    public static Entitas.IMatcher<GameEntity> MainCreator {
        get {
            if (_matcherMainCreator == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MainCreator);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMainCreator = matcher;
            }

            return _matcherMainCreator;
        }
    }
}
