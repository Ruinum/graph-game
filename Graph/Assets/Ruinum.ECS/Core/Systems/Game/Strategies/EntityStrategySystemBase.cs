using System.Collections.Generic;
using Ruinum.ECS.Extensions;
using Ruinum.ECS.Core.Extensions.Native;
using Ruinum.ECS.Core.Systems.Log;
using Entitas;

namespace Ruinum.ECS.Systems.Game.Strategies
{
    public abstract class EntityStrategySystemBase : IExecuteSystem
    {
        private const int SafetyLimit = 10000;
        private readonly ICollector<GameEntity> _createCollector;
        private readonly ICollector<GameEntity> _processCollector;
        private readonly IGroup<GameEntity> _processGroup;
        private readonly List<GameEntity> _createBuffer = new List<GameEntity>();
        private readonly List<GameEntity> _processBuffer = new List<GameEntity>();
        private readonly int _createIndex;
        private readonly int _processIndex;
        private int _iterator;
        private int _processCollectorCount;
        private int _createCollectorCount;

        protected EntityStrategySystemBase(IContext<GameEntity> context, IMatcher<GameEntity> createMatcher, IMatcher<GameEntity> processMatcher, int createIndex, int processIndex)
        {
            _createIndex = createIndex;
            _processIndex = processIndex;
            _createCollector = context.CreateCollector(createMatcher);
            _processCollector = context.CreateCollector(processMatcher);
            _processGroup = context.GetGroup(processMatcher);
        }

        public void Execute()
        {
            if (_createCollector.count > 0)
            {
                ExecuteCreateStrategy();
            }
            if (_processGroup.count > 0)
            {
                if (_processCollector.count > 0)
                {
                    _processCollector.ClearCollectedEntities();
                }
                _processGroup.GetEntities(_processBuffer);
                ExecuteAndClearProcessStrategy();
            }
            SetCollectorCount();
            if (_processCollectorCount == 0 && _createCollectorCount == 0)
            {
                return;
            }
            _iterator = 0;
            do
            {
                if (_createCollectorCount > 0)
                {
                    ExecuteCreateStrategy();
                }
                if (_processCollectorCount > 0)
                {
                    BufferAndClearCollector(_processCollector, _processBuffer, _processIndex);
                    ExecuteAndClearProcessStrategy();
                }
                SetCollectorCount();
                _iterator++;
            } while (_iterator < SafetyLimit && (_createCollectorCount > 0 || _processCollectorCount > 0));
            if (_iterator >= SafetyLimit)
            {
                LogExtention.Error($"{this.GetTypeName()} safety limit overflow");
            }
        }

        private void SetCollectorCount()
        {
            _processCollectorCount = _processCollector.count;
            _createCollectorCount = _createCollector.count;
        }

        private void ExecuteCreateStrategy()
        {
            BufferAndClearCollector(_createCollector, _createBuffer, _createIndex);
            for (int i = 0, max = _createBuffer.Count; i < max; i++)
            {
                var filteredEntity = _createBuffer[i];
                filteredEntity.GetComponent<EntityStrategyComponentBase>(_createIndex).Strategy.Process(filteredEntity);
            }
            _createBuffer.Clear();
        }

        private void ExecuteAndClearProcessStrategy()
        {
            for (int i = 0, max = _processBuffer.Count; i < max; i++)
            {
                var entity = _processBuffer[i];
                entity.GetComponent<EntityStrategyComponentBase>(_processIndex).Strategy.Process(entity);
            }
            _processBuffer.Clear();
        }

        private static void BufferAndClearCollector(ICollector<GameEntity> collector, List<GameEntity> buffer, int componentIndex)
        {
            foreach (var entity in collector.collectedEntities)
            {
                if (entity.HasComponent(componentIndex))
                {
                    buffer.Add(entity);
                }
            }
            collector.ClearCollectedEntities();
        }
    }
}