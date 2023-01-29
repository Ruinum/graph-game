using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public sealed class RemoveComponentStrategy : EntityStrategy
    {
        [HideReferenceObjectPicker, HideLabel][LabelWidth(EditorConstants.MiddleLabelWidth)] public ComponentsContainer Components = new ComponentsContainer();

        public override bool Process(GameEntity entity)
        {
            for (int i = 0, max = Components.ComponentIndexes.Length; i < max; i++)
            {
                if (entity.HasComponent(Components.ComponentIndexes[i]))
                {
                    entity.RemoveComponent(Components.ComponentIndexes[i]);
                }
                else
                {
                    if(Logging) LogError($"{nameof(RemoveComponentStrategy)} component not exists on entity {entity}");
                }
            }
            return true;
        }
    }
}