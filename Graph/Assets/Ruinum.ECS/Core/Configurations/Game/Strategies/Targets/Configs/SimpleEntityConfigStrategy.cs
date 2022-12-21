using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.Configs
{
    public sealed class SimpleEntityConfigStrategy : EntityConfigStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public GameEntityConfig Config;

        public override bool TryGet(GameEntity entity, out GameEntityConfig config)
        {
            config = Config;
            return true;
        }
    }
}