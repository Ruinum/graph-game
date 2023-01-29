using Ruinum.ECS.Services.Interfaces;

namespace Ruinum.ECS.Systems
{
    public class TimeSystems : Feature
    {
        public TimeSystems(Contexts contexts, IGameServices services)
        {
            Add(new TimeMultiplierSystem(contexts.game));
            Add(new TimeStartSystem(contexts.game));
            Add(new TimeLoopSystem(contexts.game));
            Add(new TimeDecreaseSystem(contexts.game));
        }
    }
}