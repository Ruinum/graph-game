//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SecondFloatValueListenerComponent secondFloatValueListener { get { return (SecondFloatValueListenerComponent)GetComponent(GameComponentsLookup.SecondFloatValueListener); } }
    public bool hasSecondFloatValueListener { get { return HasComponent(GameComponentsLookup.SecondFloatValueListener); } }

    public void AddSecondFloatValueListener(System.Collections.Generic.List<ISecondFloatValueListener> newValue) {
        var index = GameComponentsLookup.SecondFloatValueListener;
        var component = (SecondFloatValueListenerComponent)CreateComponent(index, typeof(SecondFloatValueListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSecondFloatValueListener(System.Collections.Generic.List<ISecondFloatValueListener> newValue) {
        var index = GameComponentsLookup.SecondFloatValueListener;
        var component = (SecondFloatValueListenerComponent)CreateComponent(index, typeof(SecondFloatValueListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSecondFloatValueListener() {
        RemoveComponent(GameComponentsLookup.SecondFloatValueListener);
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

    static Entitas.IMatcher<GameEntity> _matcherSecondFloatValueListener;

    public static Entitas.IMatcher<GameEntity> SecondFloatValueListener {
        get {
            if (_matcherSecondFloatValueListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SecondFloatValueListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSecondFloatValueListener = matcher;
            }

            return _matcherSecondFloatValueListener;
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

    public void AddSecondFloatValueListener(ISecondFloatValueListener value) {
        var listeners = hasSecondFloatValueListener
            ? secondFloatValueListener.value
            : new System.Collections.Generic.List<ISecondFloatValueListener>();
        listeners.Add(value);
        ReplaceSecondFloatValueListener(listeners);
    }

    public void RemoveSecondFloatValueListener(ISecondFloatValueListener value, bool removeComponentWhenEmpty = true) {
        var listeners = secondFloatValueListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveSecondFloatValueListener();
        } else {
            ReplaceSecondFloatValueListener(listeners);
        }
    }
}
