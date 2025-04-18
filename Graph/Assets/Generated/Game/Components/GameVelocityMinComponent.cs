//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public VelocityMinComponent velocityMin { get { return (VelocityMinComponent)GetComponent(GameComponentsLookup.VelocityMin); } }
    public bool hasVelocityMin { get { return HasComponent(GameComponentsLookup.VelocityMin); } }

    public void AddVelocityMin(float newValue) {
        var index = GameComponentsLookup.VelocityMin;
        var component = (VelocityMinComponent)CreateComponent(index, typeof(VelocityMinComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceVelocityMin(float newValue) {
        var index = GameComponentsLookup.VelocityMin;
        var component = (VelocityMinComponent)CreateComponent(index, typeof(VelocityMinComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveVelocityMin() {
        RemoveComponent(GameComponentsLookup.VelocityMin);
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

    static Entitas.IMatcher<GameEntity> _matcherVelocityMin;

    public static Entitas.IMatcher<GameEntity> VelocityMin {
        get {
            if (_matcherVelocityMin == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VelocityMin);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVelocityMin = matcher;
            }

            return _matcherVelocityMin;
        }
    }
}
