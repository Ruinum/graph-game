using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Linq;

namespace Ruinum.ECS.Core.Conditions
{
    public class AnyCondition : EntityCondition
    {
        public List<IEntityCondition> Conditions;

        protected override bool IsTrue(GameEntity entity)
        {
            return Conditions.Any(condition => condition.IsConditionTrue(entity));
        }
    }
}