//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SceneLoadedComponent sceneLoadedComponent = new SceneLoadedComponent();

    public bool isSceneLoaded {
        get { return HasComponent(GameComponentsLookup.SceneLoaded); }
        set {
            if (value != isSceneLoaded) {
                var index = GameComponentsLookup.SceneLoaded;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : sceneLoadedComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherSceneLoaded;

    public static Entitas.IMatcher<GameEntity> SceneLoaded {
        get {
            if (_matcherSceneLoaded == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SceneLoaded);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSceneLoaded = matcher;
            }

            return _matcherSceneLoaded;
        }
    }
}
