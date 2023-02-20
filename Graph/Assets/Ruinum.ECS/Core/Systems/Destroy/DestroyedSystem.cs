using System;
using Ruinum.ECS.Systems.Game.Subscribers;
using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Destroy
{
    public sealed class DestroyedSystem : IExecuteSystem
    {
        private const int SafetyLimit = 10000;
        private int _iterator;
        private readonly ReactiveSystemCollectorExtended<GameEntity> _subSystem;
        private readonly ReactiveSystemCollectorExtended<GameEntity> _pubSystem;
        
        public DestroyedSystem(IContext<GameEntity> context)
        {
            _subSystem = new EntitySubscriberSystem<DestroyedSubscriberComponent, DestroyedPublisherComponent, DestroyedComponent>(context, GameMatcher.DestroyedSubscriber);
            _pubSystem = new DestroyedPublisherSystem(context);
        }

        public void Execute()
        {
            _iterator = 0;
            while (true)
            {
                _pubSystem.Execute();
                _subSystem.Execute();
                _iterator++;
                if (_subSystem.CollectorCount == 0 && _pubSystem.CollectorCount == 0)
                {
                    break;
                }
                if (_iterator > SafetyLimit)
                {
                    throw new Exception($"[{nameof(DestroyedSystem)}] : Safety limit reached");
                }
            }
        }
    }
}