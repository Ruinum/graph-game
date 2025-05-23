//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MeshListenerComponent meshListener { get { return (MeshListenerComponent)GetComponent(GameComponentsLookup.MeshListener); } }
    public bool hasMeshListener { get { return HasComponent(GameComponentsLookup.MeshListener); } }

    public void AddMeshListener(System.Collections.Generic.List<IMeshListener> newValue) {
        var index = GameComponentsLookup.MeshListener;
        var component = (MeshListenerComponent)CreateComponent(index, typeof(MeshListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMeshListener(System.Collections.Generic.List<IMeshListener> newValue) {
        var index = GameComponentsLookup.MeshListener;
        var component = (MeshListenerComponent)CreateComponent(index, typeof(MeshListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMeshListener() {
        RemoveComponent(GameComponentsLookup.MeshListener);
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

    static Entitas.IMatcher<GameEntity> _matcherMeshListener;

    public static Entitas.IMatcher<GameEntity> MeshListener {
        get {
            if (_matcherMeshListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MeshListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMeshListener = matcher;
            }

            return _matcherMeshListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddMeshListener(IMeshListener value) {
        var listeners = hasMeshListener
            ? meshListener.value
            : new System.Collections.Generic.List<IMeshListener>();
        listeners.Add(value);
        ReplaceMeshListener(listeners);
    }

    public void RemoveMeshListener(IMeshListener value, bool removeComponentWhenEmpty = true) {
        var listeners = meshListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveMeshListener();
        } else {
            ReplaceMeshListener(listeners);
        }
    }
}
