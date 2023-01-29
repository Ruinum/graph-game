using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Conditions.Entities.Float
{
    public abstract class FloatValueCondition : ContextInitializable, IFloatValueCondition
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public bool Negate;

        public bool IsConditionTrue(GameEntity entity, float value)
        {
            return Negate ? !IsTrue(entity, value) : IsTrue(entity, value);
        }

        protected abstract bool IsTrue(GameEntity entity, float value);
    }
}