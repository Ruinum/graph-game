using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets.All.Conditions
{
    public abstract class EntityFilterCondition : ContextInitializable, IEntityFilterCondition
    {
        [LabelWidth(EditorConstants.MiddleLabelWidth)] public bool Negate;

        public bool IsConditionTrue(GameEntity entity, GameEntity target)
        {
            return Negate ? !IsTrue(entity, target) : IsTrue(entity, target);
        }

        protected abstract bool IsTrue(GameEntity entity, GameEntity target);
    }
}