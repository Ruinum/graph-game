using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.CreateStrategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class CreateChildEntitiesTargetAllStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetStrategy CreatorStrategy = new CurrentEntityTargetStrategy();
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetStrategy TargetOwnerStrategy = new CurrentEntityTargetStrategy();
        [HideReferenceObjectPicker][LabelWidth(EditorConstants.MiddleLabelWidth)]  public ConfigData[] FilteredConfigs = new ConfigData[0];

        public override bool TryGet(GameEntity entity, List<GameEntity> buffer)
        {
            if (!CreatorStrategy.TryGet(entity, out var creator))
            {
                if(Logging) LogErrorNotFound(nameof(creator), (nameof(entity), entity));
                return false;
            }
            for (int i = 0, max = buffer.Count; i < max; i++)
            {
                if (TargetOwnerStrategy.TryGet(buffer[i], out var targetOwner))
                {
                    CreateEntities(targetOwner, creator);
                }
            }
            return true;
        }

        private void CreateEntities(GameEntity ownerEntity, GameEntity creatorEntity)
        {
            for (int i = 0, max = FilteredConfigs.Length; i < max; i++)
            {
                CreateEntities(FilteredConfigs[i], ownerEntity, creatorEntity);
            }
        }

        private static void CreateEntities(ConfigData config, GameEntity ownerEntity, GameEntity creatorEntity)
        {
            var entity = config.Config.Create(ownerEntity);
            //entity.ReplaceCreatorEntity(creatorEntity);
            for (int i = 0, max = config.ProcessData.Length; i < max; i++)
            {
                ProcessTargetToCreatedData(creatorEntity, entity, config.ProcessData[i]);
            }
        }

        private static void ProcessTargetToCreatedData(GameEntity entity, GameEntity createdEntity, TargetToCreatedStrategyData data)
        {
            if (data.TargetStrategy.TryGet(entity, out var targetEntity) && data.CreatedTargetStrategy.TryGet(createdEntity, out var createdTargetEntity))
            {
                data.ProcessStrategy.Process(targetEntity, createdTargetEntity);
            }
        }

        public class ConfigData
        {
            [LabelWidth(EditorConstants.SmallLabelWidth)] public GameEntityConfig Config;
            [HideReferenceObjectPicker][LabelWidth(EditorConstants.SmallLabelWidth)]  public TargetToCreatedStrategyData[] ProcessData = new TargetToCreatedStrategyData[0];
        }
    }
}