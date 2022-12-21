using Ruinum.ECS.Services.Interfaces;


namespace Ruinum.ECS.Extensions
{
    public static class ContextExtensions
    {
        public static IConfigService GetConfigService(this Contexts contexts)
        {
            return contexts.game.services.Instance.Config;
        }
    }
}