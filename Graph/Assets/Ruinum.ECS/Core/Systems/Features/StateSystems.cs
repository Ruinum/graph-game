using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.States;

namespace Ruinum.ECS.Systems.Features
{
    public sealed class StateSystems : Feature
    {
        public StateSystems(Contexts contexts, IGameServices services)
        {
            Add(new DestroyStrategySystem(contexts.game));

            Add(new TimeLoopSystem(contexts.game));
        }
    }
}