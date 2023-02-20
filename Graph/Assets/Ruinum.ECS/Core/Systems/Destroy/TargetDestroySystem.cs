using System.Collections.Generic;
using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Destroy
{
    public sealed class TargetDestroySystem : ReactiveSystemExtended<GameEntity>
    {
        private readonly EntityIndex<GameEntity, GameEntity> _entityIndex;
        private readonly List<GameEntity> _buffer = new List<GameEntity>();

        public TargetDestroySystem(IContext<GameEntity> context) : base(context)
        {
            _entityIndex = (EntityIndex<GameEntity, GameEntity>)context.GetEntityIndex(Contexts.GameTarget);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroyed;
        }

        protected override void Execute(GameEntity e)
        {
            var entities = _entityIndex.GetEntities(e);
            if (entities.Count <= 0)
            {
                return;
            }
            _buffer.AddRange(entities);
            for (int i = 0, max = _buffer.Count; i < max; i++)
            {
                _buffer[i].RemoveGameTarget();
            }
            _buffer.Clear();
        }
    }
}