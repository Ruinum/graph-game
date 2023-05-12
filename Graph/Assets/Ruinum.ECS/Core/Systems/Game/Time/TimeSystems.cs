namespace Ruinum.ECS.Systems.Features
{
    public class TimeSystems : Feature
    {
        public TimeSystems(Contexts contexts)
        {
            Add(new TimeMultiplierSystem(contexts.game));
            Add(new TimeStartSystem(contexts.game));
            Add(new TimeDecreaseSystem(contexts.game));
        }
    }
}