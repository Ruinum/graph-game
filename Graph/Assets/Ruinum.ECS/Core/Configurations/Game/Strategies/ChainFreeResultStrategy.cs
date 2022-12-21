using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    public sealed class ChainFreeResultStrategy : EntityStrategy
    {
        [AssetSelector(Filter = "t:EntityStrategyConfig", DisableListAddButtonBehaviour = true)] [ListDrawerSettings(CustomAddFunction = nameof(OnButtonAdd))][LabelWidth(EditorConstants.SmallLabelWidth)]  public IEntityStrategy[] Strategies = new IEntityStrategy[0];

        public override bool Process(GameEntity entity)
        {
            for (int i = 0, max = Strategies.Length; i < max; i++)
            {
                if (!Strategies[i].Process(entity))
                {
                    if (Logging) LogError($"Strategy result false at {i}. Strategy: {Strategies[i].GetType().Name}");
                }
            }
            return true;
        }

        private IEntityStrategy OnButtonAdd() => null;
    }
}