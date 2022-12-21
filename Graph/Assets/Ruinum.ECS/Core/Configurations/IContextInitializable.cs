using Ruinum.ECS.Services.Interfaces;


namespace Ruinum.ECS.Configurations.Game
{
    public interface IContextInitializable
    {
        void Initialize(Contexts contexts, IGameServices services);
    }
}