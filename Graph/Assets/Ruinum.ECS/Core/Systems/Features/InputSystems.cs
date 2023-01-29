using Ruinum.ECS.Components.Input;
using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Input;

namespace Ruinum.ECS.Systems.Features
{
    public sealed class InputSystems : Feature
    {
        public InputSystems(Contexts contexts, IGameServices services)
        {
            Add(new DefaultInputDomainInitializeSystem());
            Add(new InputDomainSystem(contexts.input, contexts.game));
            Add(new InputDomainActionMapSystem(contexts.input, services.Input));
        }
    }
}