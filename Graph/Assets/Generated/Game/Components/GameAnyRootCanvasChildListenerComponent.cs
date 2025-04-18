//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyRootCanvasChildListenerComponent anyRootCanvasChildListener { get { return (AnyRootCanvasChildListenerComponent)GetComponent(GameComponentsLookup.AnyRootCanvasChildListener); } }
    public bool hasAnyRootCanvasChildListener { get { return HasComponent(GameComponentsLookup.AnyRootCanvasChildListener); } }

    public void AddAnyRootCanvasChildListener(System.Collections.Generic.List<IAnyRootCanvasChildListener> newValue) {
        var index = GameComponentsLookup.AnyRootCanvasChildListener;
        var component = (AnyRootCanvasChildListenerComponent)CreateComponent(index, typeof(AnyRootCanvasChildListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyRootCanvasChildListener(System.Collections.Generic.List<IAnyRootCanvasChildListener> newValue) {
        var index = GameComponentsLookup.AnyRootCanvasChildListener;
        var component = (AnyRootCanvasChildListenerComponent)CreateComponent(index, typeof(AnyRootCanvasChildListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyRootCanvasChildListener() {
        RemoveComponent(GameComponentsLookup.AnyRootCanvasChildListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyRootCanvasChildListener;

    public static Entitas.IMatcher<GameEntity> AnyRootCanvasChildListener {
        get {
            if (_matcherAnyRootCanvasChildListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyRootCanvasChildListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyRootCanvasChildListener = matcher;
            }

            return _matcherAnyRootCanvasChildListener;
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

    public void AddAnyRootCanvasChildListener(IAnyRootCanvasChildListener value) {
        var listeners = hasAnyRootCanvasChildListener
            ? anyRootCanvasChildListener.value
            : new System.Collections.Generic.List<IAnyRootCanvasChildListener>();
        listeners.Add(value);
        ReplaceAnyRootCanvasChildListener(listeners);
    }

    public void RemoveAnyRootCanvasChildListener(IAnyRootCanvasChildListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyRootCanvasChildListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyRootCanvasChildListener();
        } else {
            ReplaceAnyRootCanvasChildListener(listeners);
        }
    }
}
