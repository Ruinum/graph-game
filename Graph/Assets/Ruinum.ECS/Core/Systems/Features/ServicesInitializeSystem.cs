using Entitas;
using Ruinum.ECS.Services.Interfaces;

namespace Ruinum.ECS.Systems.Features
{
    public sealed class ServicesInitializeSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IGameServices _services;

        public ServicesInitializeSystem(Contexts contexts, IGameServices services)
        {
            _contexts = contexts;
            _services = services;
        }

        public void Initialize()
        {
            _contexts.game.ReplaceServices(_services);
        }
    }
}