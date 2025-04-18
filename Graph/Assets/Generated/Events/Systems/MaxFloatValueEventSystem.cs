//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class MaxFloatValueEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IMaxFloatValueListener> _listenerBuffer;

    public MaxFloatValueEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IMaxFloatValueListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.MaxFloatValue)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasMaxFloatValue && entity.hasMaxFloatValueListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.maxFloatValue;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.maxFloatValueListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnMaxFloatValue(e, component.Value);
            }
        }
    }
}
