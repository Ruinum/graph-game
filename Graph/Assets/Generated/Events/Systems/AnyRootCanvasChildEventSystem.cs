//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class AnyRootCanvasChildEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly Entitas.IGroup<GameEntity> _listeners;
    readonly System.Collections.Generic.List<GameEntity> _entityBuffer;
    readonly System.Collections.Generic.List<IAnyRootCanvasChildListener> _listenerBuffer;

    public AnyRootCanvasChildEventSystem(Contexts contexts) : base(contexts.game) {
        _listeners = contexts.game.GetGroup(GameMatcher.AnyRootCanvasChildListener);
        _entityBuffer = new System.Collections.Generic.List<GameEntity>();
        _listenerBuffer = new System.Collections.Generic.List<IAnyRootCanvasChildListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.RootCanvasChild)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.isRootCanvasChild;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            
            foreach (var listenerEntity in _listeners.GetEntities(_entityBuffer)) {
                _listenerBuffer.Clear();
                _listenerBuffer.AddRange(listenerEntity.anyRootCanvasChildListener.value);
                foreach (var listener in _listenerBuffer) {
                    listener.OnAnyRootCanvasChild(e);
                }
            }
        }
    }
}
