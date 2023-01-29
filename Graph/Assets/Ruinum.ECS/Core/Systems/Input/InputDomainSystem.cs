using System.Collections.Generic;
using Ruinum.ECS.Configurations.Input;
using Ruinum.ECS.Integration.Entitas;
using Entitas;
using System.Linq;

namespace Ruinum.ECS.Systems.Input
{
    public sealed class InputDomainSystem : ReactiveSystemExtended<GameEntity>
    {
        private readonly InputContext _inputContext;
        private readonly List<(GameEntity entity, InputDomainConfig config)> _configs = new List<(GameEntity, InputDomainConfig)>();

        public InputDomainSystem(InputContext inputContext, IContext<GameEntity> gameContext) : base(gameContext)
        {
            _inputContext = inputContext;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.InputDomainGame.AddedOrRemoved());

        protected override bool Filter(GameEntity entity) => true;

        protected override void Execute(GameEntity e)
        {
            if (e.hasInputDomainGame)
            {
                OnAdded(e);
            }
            else
            {
                OnRemoved(e);
            }
        }

        private void OnAdded(GameEntity e)
        {
            var config = e.inputDomainGame.Config;
            _configs.Add((e, e.inputDomainGame.Config));
            if (!_inputContext.hasInputDomain || _inputContext.inputDomain.Config != config)
            {
                _inputContext.ReplaceInputDomain(config);
            }
        }

        private void OnRemoved(GameEntity e)
        {
            _configs.RemoveAll(m => m.entity == e);
            if (_configs.Count == 0)
            {
                return;
            }
            var (_, config) = _configs.Last();
            if (_inputContext.inputDomain.Config != config)
            {
                _inputContext.ReplaceInputDomain(config);
            }
        }
    }
}

