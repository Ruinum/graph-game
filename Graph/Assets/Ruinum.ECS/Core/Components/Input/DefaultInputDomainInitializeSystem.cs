using Ruinum.ECS.Extensions;
using Entitas;

namespace Ruinum.ECS.Components.Input
{  
    public sealed class DefaultInputDomainInitializeSystem : IInitializeSystem
    {
        public void Initialize()
        {
            var defaultInputDomain = Contexts.sharedInstance.GetConfigService().SharedConfig.DefaultInputDomain;

            var gameContext = Contexts.sharedInstance.game;
            gameContext.CreateEntity().AddInputDomainGame(defaultInputDomain);       
            gameContext.services.Instance.Input.SetAxisMap(defaultInputDomain.ActionMap);
        }
    }
}