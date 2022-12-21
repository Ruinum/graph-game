using Entitas;

namespace Ruinum.ECS.Integration.Entitas
{
    public abstract class ReactiveSystemCollectorExtended<TEntity> : ReactiveSystemExtended<TEntity> where TEntity : class, IEntity
    {
        private readonly ICollector<TEntity> _collector;

        public int CollectorCount => _collector.count;

        protected ReactiveSystemCollectorExtended(ICollector<TEntity> collector) : base(collector)
        {
            _collector = collector;
        }

        protected sealed override ICollector<TEntity> GetTrigger(IContext<TEntity> context) => throw new System.NotImplementedException();
    }
}