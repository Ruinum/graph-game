using System.Collections.Generic;
using System.Linq;

namespace Ruinum.ECS.Core.Conditions
{
    public class AllCondition : EntityCondition
    {
        public List<IEntityCondition> Conditions;

        protected override bool IsTrue(GameEntity entity)
        {
            return Conditions.All(condition => condition.IsConditionTrue(entity));
        }
    }
}