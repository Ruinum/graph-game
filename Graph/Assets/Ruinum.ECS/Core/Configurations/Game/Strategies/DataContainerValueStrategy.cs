using Ruinum.ECS.Configurations.Components;
using Ruinum.ECS.Configurations.Components.Data;
using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Targets;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public abstract class DataContainerValueStrategy<T> : ContextInitializable where T : IComponentData
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public ITargetStrategy Target = new CurrentEntityTargetStrategy();
        [HideReferenceObjectPicker, HideLabel][LabelWidth(EditorConstants.MiddleLabelWidth)] public ComponentDataTypeConfigElement<T> DataType = new ComponentDataTypeConfigElement<T>();

        public bool TryGetComponentData(GameEntity entity, out T data)
        {
            if (!Target.TryGet(entity, out var targetEntity))
            {
                data = default;
                if (Logging) LogErrorNotFound(nameof(targetEntity), (nameof(entity), entity));
                return false;
            }

            if (!targetEntity.hasComponentDataContainer)
            {
                data = default;
                if (Logging) LogErrorNotFound("ComponentDataContainerComponent", (nameof(entity), entity), (nameof(targetEntity), targetEntity));
                return false;
            }

            if (!targetEntity.componentDataContainer.Value.TryGetValue(DataType.Id, out data))
            {
                if (DataType.DataTypeConfig.TryGetComponentDataType(DataType.Id, out var componentDataType))
                {
                    if (Logging) LogErrorNotFound($"data of type {componentDataType.Name} in {DataType.DataTypeConfig.name}",
                         (nameof(entity), entity), (nameof(targetEntity), targetEntity), ("Container: ", targetEntity.componentDataContainer.Value.name));
                }
                else
                {
                    if (Logging) LogErrorNotFound($"DataType in {DataType.DataTypeConfig.name} with id {DataType.Id}",
                         (nameof(targetEntity), targetEntity));
                }

                data = default;
                return false;
            }
            return true;
        }
    }
}