using Ruinum.ECS.Core.Conditions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public sealed class StrategyConditionData
    {
        [LabelWidth(100), AssetSelector(Filter = "t:EntityConditionConfig")] public IEntityCondition Condition;
        [LabelWidth(100), AssetSelector(Filter = "t:EntityStrategyConfig")] public IEntityStrategy Strategy;
    }
}