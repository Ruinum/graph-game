using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class SceneConfigEntityStrategy : EntityStrategy
    {
        public ITargetStrategy Target;
        public ISceneConfigStrategy Strategy;

        public override bool Process(GameEntity entity)
        {
            if (!Target.TryGet(entity, out var target)) { return false; };
            if (!Strategy.TryGet(entity, out var value)) { return false; }
            if (!target.hasTime) { return false; }

            target.ReplaceSceneConfig(value);

            return true;
        }
    }
}