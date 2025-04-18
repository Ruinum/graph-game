//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MaxFloatValueListenerComponent maxFloatValueListener { get { return (MaxFloatValueListenerComponent)GetComponent(GameComponentsLookup.MaxFloatValueListener); } }
    public bool hasMaxFloatValueListener { get { return HasComponent(GameComponentsLookup.MaxFloatValueListener); } }

    public void AddMaxFloatValueListener(System.Collections.Generic.List<IMaxFloatValueListener> newValue) {
        var index = GameComponentsLookup.MaxFloatValueListener;
        var component = (MaxFloatValueListenerComponent)CreateComponent(index, typeof(MaxFloatValueListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMaxFloatValueListener(System.Collections.Generic.List<IMaxFloatValueListener> newValue) {
        var index = GameComponentsLookup.MaxFloatValueListener;
        var component = (MaxFloatValueListenerComponent)CreateComponent(index, typeof(MaxFloatValueListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMaxFloatValueListener() {
        RemoveComponent(GameComponentsLookup.MaxFloatValueListener);
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

    static Entitas.IMatcher<GameEntity> _matcherMaxFloatValueListener;

    public static Entitas.IMatcher<GameEntity> MaxFloatValueListener {
        get {
            if (_matcherMaxFloatValueListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MaxFloatValueListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMaxFloatValueListener = matcher;
            }

            return _matcherMaxFloatValueListener;
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

    public void AddMaxFloatValueListener(IMaxFloatValueListener value) {
        var listeners = hasMaxFloatValueListener
            ? maxFloatValueListener.value
            : new System.Collections.Generic.List<IMaxFloatValueListener>();
        listeners.Add(value);
        ReplaceMaxFloatValueListener(listeners);
    }

    public void RemoveMaxFloatValueListener(IMaxFloatValueListener value, bool removeComponentWhenEmpty = true) {
        var listeners = maxFloatValueListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveMaxFloatValueListener();
        } else {
            ReplaceMaxFloatValueListener(listeners);
        }
    }
}
