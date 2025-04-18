//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public OwnerEntityTypeIndexKeyComponent ownerEntityTypeIndexKey { get { return (OwnerEntityTypeIndexKeyComponent)GetComponent(GameComponentsLookup.OwnerEntityTypeIndexKey); } }
    public bool hasOwnerEntityTypeIndexKey { get { return HasComponent(GameComponentsLookup.OwnerEntityTypeIndexKey); } }

    public void AddOwnerEntityTypeIndexKey(Ruinum.ECS.Services.Index.RootOwnerEntityTypeIndexer.Key newValue) {
        var index = GameComponentsLookup.OwnerEntityTypeIndexKey;
        var component = (OwnerEntityTypeIndexKeyComponent)CreateComponent(index, typeof(OwnerEntityTypeIndexKeyComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceOwnerEntityTypeIndexKey(Ruinum.ECS.Services.Index.RootOwnerEntityTypeIndexer.Key newValue) {
        var index = GameComponentsLookup.OwnerEntityTypeIndexKey;
        var component = (OwnerEntityTypeIndexKeyComponent)CreateComponent(index, typeof(OwnerEntityTypeIndexKeyComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveOwnerEntityTypeIndexKey() {
        RemoveComponent(GameComponentsLookup.OwnerEntityTypeIndexKey);
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

    static Entitas.IMatcher<GameEntity> _matcherOwnerEntityTypeIndexKey;

    public static Entitas.IMatcher<GameEntity> OwnerEntityTypeIndexKey {
        get {
            if (_matcherOwnerEntityTypeIndexKey == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.OwnerEntityTypeIndexKey);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOwnerEntityTypeIndexKey = matcher;
            }

            return _matcherOwnerEntityTypeIndexKey;
        }
    }
}
