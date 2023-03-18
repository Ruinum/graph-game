using Ruinum.ECS.Configurations.Game;
using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Ruinum.ECS.Utilities;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.CreateStrategies
{
    public sealed class CreateEntityStrategy : EntityStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public GameEntityConfig EntityConfig;
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetStrategy Creator = new RootOwnerTargetStrategy();

        public override bool Process(GameEntity entity)
        {
            if (!Creator.TryGet(entity, out var creator))
            {
                if(Logging) LogErrorNotFound(nameof(creator), (nameof(entity), entity));
                return false;
            }
            var created = EntityConfig.Create();
            entity.ReplaceGameCreatedEntity(created);
            created.AddCreatorEntity(creator);
            EntityUtilities.ProcessMainCreator(entity, created);
            return true;
        }
    }
}