using BeastHour.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Components.Data;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values
{
    public sealed class FloatValueDataContainerStrategy : DataContainerValueStrategy<FloatComponentData>, IFloatValueStrategy
    {
        public bool TryGet(GameEntity entity, out float value)
        {
            if (!TryGetComponentData(entity, out var data))
            {
                value = default;
                if(Logging) LogErrorNotFound(nameof(data), (nameof(entity), entity));
                return false;
            }

            value = data.Value;
            return true;
        }
    }
}