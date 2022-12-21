using Ruinum.ECS.Configurations.Game.Strategies.Targets.Find;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class RootOwnerHierarchyTargetStrategy : TargetStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public GameEntityConfig Config;
        private IConfigTargetFindStrategy _findStrategy;

        protected override void OnInitialize()
        {
            _findStrategy = new RootOwnerHierarchyConfigTargetFindStrategy();
        }
        
        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            return _findStrategy.TryGet(entity, Config, out targetEntity);
        }
    }
}