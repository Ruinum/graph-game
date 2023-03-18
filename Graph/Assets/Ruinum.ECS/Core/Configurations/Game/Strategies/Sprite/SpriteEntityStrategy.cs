using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Core.Configurations.Game.Strategies;

public class SpriteEntityStrategy : EntityStrategy
{
    public ITargetStrategy Target;
    public ISpriteStrategy Strategy;
    public override bool Process(GameEntity entity)
    {
        if (!Target.TryGet(entity, out var target)) { return false; }
        if (!Strategy.TryGet(entity, out var strategy)) { return false; }
        target.ReplaceSprite(strategy);
        return true;
    }
}
