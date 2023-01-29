using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Input
{
    public sealed class InputDomainActionMapSystem : ReactiveSystemExtended<InputEntity>
    {
        private readonly IInputService _inputService;

        public InputDomainActionMapSystem(InputContext inputContext, IInputService inputService) : base(inputContext)
        {
            _inputService = inputService;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        { 
            return context.CreateCollector(InputMatcher.InputDomain);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasInputDomain;
        }
            

        protected override void Execute(InputEntity e)
        {
            _inputService.SetMap(e.inputDomain.Config.ActionMap);
        }
    }
}