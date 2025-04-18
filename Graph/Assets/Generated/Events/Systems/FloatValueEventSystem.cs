//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class FloatValueEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IFloatValueListener> _listenerBuffer;

    public FloatValueEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IFloatValueListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.FloatValue)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasFloatValue && entity.hasFloatValueListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.floatValue;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.floatValueListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnFloatValue(e, component.Value);
            }
        }
    }
}
