using System.Collections.Generic;
using Ruinum.ECS.Configurations.Game.CreateStrategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All
{
    public sealed class CreateEntitiesTargetAllStrategy : TargetAllStrategy
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetStrategy OwnerStrategy;
        [HideReferenceObjectPicker][LabelWidth(EditorConstants.MiddleLabelWidth)]  public ConfigData[] FilteredConfigs = new ConfigData[0];

        public override bool TryGet(GameEntity entity, List<GameEntity> buffer)
        {
            if (!OwnerStrategy.TryGet(entity, out var owner))
            {
                if(Logging) LogErrorNotFound(nameof(owner), (nameof(entity), entity));
                return false;
            }
            for (int i = 0, max = buffer.Count; i < max; i++)
            {
                CreateEntities(buffer[i], owner, entity);
            }
            return true;
        }

        private void CreateEntities(GameEntity targetEntity, GameEntity ownerEntity, GameEntity creatorEntity)
        {
            for (int i = 0, max = FilteredConfigs.Length; i < max; i++)
            {
                CreateEntities(FilteredConfigs[i], targetEntity, ownerEntity, creatorEntity);
            }
        }

        private static void CreateEntities(ConfigData config, GameEntity targetEntity, GameEntity ownerEntity, GameEntity creatorEntity)
        {
            var entity = config.Config.Create(ownerEntity);
            entity.ReplaceCreatorEntity(creatorEntity);
            entity.ReplaceGameTarget(targetEntity);
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
            [LabelWidth(EditorConstants.MiddleLabelWidth)] public GameEntityConfig Config;
            [HideReferenceObjectPicker][LabelWidth(EditorConstants.MiddleLabelWidth)] public TargetToCreatedStrategyData[] ProcessData = new TargetToCreatedStrategyData[0];
        }
    }
}