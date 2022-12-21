using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Extensions.Native;
using Entitas;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public abstract class PlainEntityStrategy<TComponent, TData> : EntityStrategy where TComponent : ValueData<TData>, IComponent, new()
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ITargetStrategy Target;
        [LabelWidth(EditorConstants.SmallLabelWidth)] public IComponentStrategy<TData> Strategy;
        private int _componentIndex;

        protected sealed override void OnInitialize()
        {
            _componentIndex = GameComponentsLookup.componentTypes.IndexOf(typeof(TComponent));
        }
        
        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target))
            {
                if(Logging) LogErrorNotFound(nameof(target), (nameof(entity), entity));
                return false;
            }

            if (!Strategy.TryGet(entity, out var data))
            {
                if(Logging) LogErrorNotFound(nameof(data), (nameof(entity), entity), (nameof(target), target));
                return false;
            }

            var component = target.CreateComponent<TComponent>(_componentIndex);
            component.Value = data;
            target.ReplaceComponent(_componentIndex, component);
            return true;
        }
    }
}