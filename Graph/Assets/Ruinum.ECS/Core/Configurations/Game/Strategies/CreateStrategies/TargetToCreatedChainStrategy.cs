using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.CreateStrategies
{
    public sealed class TargetToCreatedChainStrategy : EntityStrategy
    {
        [HideReferenceObjectPicker, LabelWidth(EditorConstants.SmallLabelWidth)] public TargetToCreatedStrategyData[] Strategies = new TargetToCreatedStrategyData[0];

        public override bool Process(GameEntity entity)
        {
            if (!entity.hasGameCreatedEntity)
            {
                if(Logging) LogErrorNotFound("GameCreatedEntityComponent", (nameof(entity), entity));
                return false;
            }
            var createdEntity = entity.gameCreatedEntity.Value;
            for (int i = 0, max = Strategies.Length; i < max; i++)
            {
                Process(entity, createdEntity, Strategies[i]);
            }
            return true;
        }

        private static void Process(GameEntity entity, GameEntity createdEntity, TargetToCreatedStrategyData data)
        {
            if (data.TargetStrategy.TryGet(entity, out var targetEntity) &&
                data.CreatedTargetStrategy.TryGet(createdEntity, out var createdTargetEntity))
            {
                data.ProcessStrategy.Process(targetEntity, createdTargetEntity);
            }
        }
    }
}