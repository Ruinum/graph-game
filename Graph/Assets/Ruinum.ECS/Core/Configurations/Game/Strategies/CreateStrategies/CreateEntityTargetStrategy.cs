using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.CreateStrategies
{
    public sealed class CreateEntityTargetStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public GameEntityConfig EntityConfig;
        [AssetSelector(Filter = "t:TargetStrategyConfig"), LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetStrategy OwnerStrategy = new RootOwnerTargetStrategy();
        [AssetSelector(Filter = "t:TargetStrategyConfig"), LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetStrategy CreatorStrategy = new CurrentEntityTargetStrategy();

        public override bool Process(GameEntity entity)
        {
            if (!OwnerStrategy.TryGet(entity, out var ownerEntity))
            {
                if(Logging) LogErrorNotFound(nameof(ownerEntity), (nameof(entity), entity));
                return false;
            }

            if (!CreatorStrategy.TryGet(entity, out var creator))
            {
                if(Logging) LogErrorNotFound(nameof(creator), (nameof(entity), entity), (nameof(ownerEntity), ownerEntity));
                return false;
            }

            var created = EntityConfig.Create(ownerEntity);
            entity.ReplaceGameCreatedEntity(created);
            created.AddCreatorEntity(creator);
            EntityUtilities.ProcessMainCreator(entity, created);
            return true;
        }
    }
}