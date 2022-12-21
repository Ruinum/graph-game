using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public sealed class ConditionChainEntityStrategy : EntityStrategy
    {
        [ListDrawerSettings(CustomAddFunction = nameof(Add), Expanded = true)] [HideReferenceObjectPicker][LabelWidth(EditorConstants.SmallLabelWidth)] public StrategyConditionData[] Data = new StrategyConditionData[0];

        public override bool Process(GameEntity entity)
        {
            for (int i = 0, max = Data.Length; i < max; i++)
            {
                var strategyData = Data[i];
                if (strategyData.Condition.IsConditionTrue(entity))
                {
                    strategyData.Strategy.Process(entity);
                }
            }
            return true;
        }

        private StrategyConditionData Add() => new StrategyConditionData();
    }
}