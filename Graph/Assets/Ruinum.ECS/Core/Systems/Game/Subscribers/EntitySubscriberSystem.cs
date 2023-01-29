using System;
using System.Collections.Generic;
using Ruinum.ECS.Extensions;
using Ruinum.ECS.Core.Extensions.Native;
using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Game.Subscribers
{
    public sealed class EntitySubscriberSystem<TSub, TPub, TValue> : ReactiveSystemCollectorExtended<GameEntity>, IDestroyedListener
        where TSub : EntitySubscriberComponent where TPub : EntityPublisherComponent
    {
        private readonly Type _pubType = typeof(TPub);
        private readonly int _subIndex = GameComponentsLookup.componentTypes.IndexOf(typeof(TSub));
        private readonly int _pubIndex = GameComponentsLookup.componentTypes.IndexOf(typeof(TPub));
        private readonly int _valueIndex =  GameComponentsLookup.componentTypes.IndexOf(typeof(TValue));
        private readonly Dictionary<GameEntity, GameEntity> _buffer = new Dictionary<GameEntity, GameEntity>();

        public EntitySubscriberSystem(IContext<GameEntity> context, IMatcher<GameEntity> matcher) : base(context.CreateCollector(matcher))
        {
            context.GetGroup(matcher).OnEntityRemoved += OnSubscriberRemoved;
        }

        private void OnSubscriberRemoved(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
        {
            OnDestroyed(entity);
        }
        
        protected override bool Filter(GameEntity entity)
        {
            return entity.HasComponent(_subIndex);
        }

        protected override void Execute(GameEntity subscriber)
        {
            var sub = subscriber.GetComponent<TSub>(_subIndex);
            if (!sub.Target.TryGet(subscriber, out var publisher))
            {
                return;
            }
            AddSubscriber(publisher, subscriber);
            if (publisher.HasComponent(_valueIndex))
            {
                sub.Strategy.Process(publisher, subscriber);
            }
            subscriber.AddDestroyedListener(this);
            _buffer.Add(subscriber, publisher);
        }

        private void AddSubscriber(GameEntity publisher, GameEntity subscriber)
        {
            if (publisher.HasComponent(_pubIndex))
            {
                var component = publisher.GetComponent<TPub>(_pubIndex);
                component.Subscribers.Add(subscriber);
                publisher.ReplaceComponent(_pubIndex, component);
                return;
            }

            var subscribers = new List<GameEntity>();
            var publisherComponent = (TPub)publisher.CreateComponent(_pubIndex, _pubType);
            subscribers.Add(subscriber);
            publisherComponent.Subscribers = subscribers;
            publisher.AddComponent(_pubIndex, publisherComponent);
        }

        public void OnDestroyed(GameEntity entity)
        {
            if (!_buffer.ContainsKey(entity))
            {
                return;
            }
            var publisher = _buffer[entity];
            _buffer.Remove(entity);
            if (publisher.HasComponent(_pubIndex))
            {
                publisher.GetComponent<TPub>(_pubIndex).Subscribers.Remove(entity);
            }
        }
    }
}