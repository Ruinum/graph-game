using System.Collections.Generic;
using Entitas;

namespace Ruinum.ECS.Integration.Entitas
{
    public abstract class ReactiveSystemExtended<TEntity> : ReactiveSystem<TEntity> where TEntity : class, IEntity
    {
        protected ReactiveSystemExtended(IContext<TEntity> context) : base(context)
        {
        }

        protected ReactiveSystemExtended(ICollector<TEntity> collector) : base(collector)
        {
        }

        protected sealed override void Execute(List<TEntity> entities)
        {
            for (int i = 0, max = entities.Count; i < max; i++)
            {
                Execute(entities[i]);
            }
        }

        protected abstract void Execute(TEntity entity);
    }
}