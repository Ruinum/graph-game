using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Core.Conditions
{
    public abstract class EntityCondition : ContextInitializable, IEntityCondition
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public bool Negate;

        protected abstract bool IsTrue(GameEntity entity);

        public bool IsConditionTrue(GameEntity entity)
        {
            return Negate ? IsTrue(entity) : !IsTrue(entity);
        }
    }
}