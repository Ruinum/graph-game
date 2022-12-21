using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public sealed class ConditionChainAnyEntityStrategy : EntityStrategy
    {
        [ListDrawerSettings(CustomAddFunction = nameof(Add), Expanded = true), HideReferenceObjectPicker][LabelWidth(EditorConstants.SmallLabelWidth)]  public StrategyConditionData[] Data = new StrategyConditionData[0];

        public override bool Process(GameEntity entity)
        {
            for (int i = 0, max = Data.Length; i < max; i++)
            {
                var strategyData = Data[i];
                if (strategyData.Condition.IsConditionTrue(entity))
                {
                    if (!strategyData.Strategy.Process(entity))
                    {
                        if (Logging) LogError($"Strategy result false at {i}. Strategy: {strategyData.Strategy.GetType().Name}");
                        return false;
                    }
                    return true;
                }
            }
            return true;
        }

        private StrategyConditionData Add() => new StrategyConditionData();
    }
}