//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public VelocityModifierComponent velocityModifier { get { return (VelocityModifierComponent)GetComponent(GameComponentsLookup.VelocityModifier); } }
    public bool hasVelocityModifier { get { return HasComponent(GameComponentsLookup.VelocityModifier); } }

    public void AddVelocityModifier(float newValue) {
        var index = GameComponentsLookup.VelocityModifier;
        var component = (VelocityModifierComponent)CreateComponent(index, typeof(VelocityModifierComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceVelocityModifier(float newValue) {
        var index = GameComponentsLookup.VelocityModifier;
        var component = (VelocityModifierComponent)CreateComponent(index, typeof(VelocityModifierComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveVelocityModifier() {
        RemoveComponent(GameComponentsLookup.VelocityModifier);
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

    static Entitas.IMatcher<GameEntity> _matcherVelocityModifier;

    public static Entitas.IMatcher<GameEntity> VelocityModifier {
        get {
            if (_matcherVelocityModifier == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VelocityModifier);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVelocityModifier = matcher;
            }

            return _matcherVelocityModifier;
        }
    }
}
