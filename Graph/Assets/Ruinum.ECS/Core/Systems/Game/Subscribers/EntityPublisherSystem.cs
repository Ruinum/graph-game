using Ruinum.ECS.Extensions;
using Ruinum.ECS.Core.Extensions.Native;
using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Game.Subscribers
{
    public class EntityPublisherSystem<TSub, TPub> : ReactiveSystemCollectorExtended<GameEntity> where TPub : EntityPublisherComponent where TSub : EntitySubscriberComponent
    {
        private readonly int _pubIndex = GameComponentsLookup.componentTypes.IndexOf(typeof(TPub));
        private readonly int _subIndex = GameComponentsLookup.componentTypes.IndexOf(typeof(TSub));
        
        public EntityPublisherSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }
        
        protected sealed override bool Filter(GameEntity entity)
        { 
            return entity.HasComponent(_pubIndex) && OnFilter(entity);
        }

        protected virtual bool OnFilter(GameEntity entity)
        {
            return true;
        }
         
        protected override void Execute(GameEntity publisher)
        {
            var subscribers = publisher.GetComponent<TPub>(_pubIndex).Subscribers;
            for (int i = 0, max = subscribers.Count; i < max; i++)
            {
                var subscriber = subscribers[i];
                if (subscriber.HasComponent(_subIndex))
                {
                    subscriber.GetComponent<TSub>(_subIndex).Strategy.Process(publisher, subscriber);
                }
            }
        }
    }
}