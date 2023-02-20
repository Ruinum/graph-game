using Ruinum.ECS.Configurations.Game.Strategies.Subscribers.Values;
using Ruinum.ECS.Configurations.Game.Strategies.Texts;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public sealed class StringFloatTextStrategy : TextStrategy
    {
        public IFloatValueStrategy Strategy;        

        public override bool TryGet(GameEntity entity, out string text)
        {
            text = default;
            if (!Strategy.TryGet(entity, out var value))
            {
                if(Logging) LogErrorNotFound("TextComponent", (nameof(entity), entity), (nameof(Strategy), Strategy));
                return false;
            }

            text += value;
            return true;
        }
    }
}