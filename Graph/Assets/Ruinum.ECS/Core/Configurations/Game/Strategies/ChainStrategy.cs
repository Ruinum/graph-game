using Ruinum.ECS.Constants;
using Ruinum.ECS.Core.Systems.Log;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies
{
    [System.Serializable]
    public sealed class ChainStrategy : EntityStrategy
    {
        [AssetSelector(Filter = "t:EntityStrategyConfig", DisableListAddButtonBehaviour = true)] [ListDrawerSettings(CustomAddFunction = nameof(OnButtonAdd))][LabelWidth(EditorConstants.SmallLabelWidth)]  public IEntityStrategy[] Strategies = new IEntityStrategy[0];

        public override bool Process(GameEntity entity)
        {
            for (int i = 0, max = Strategies.Length; i < max; i++)
            {
                var entityStrategy = Strategies[i];
                if (!entityStrategy.Process(entity))
                {
                    if (Logging) LogExtention.Log($"entity strategy result with type {entityStrategy.GetType().Name} not found at {i}. Entity {entity}");
                    return false;
                }
            }
            return true;
        }

        private IEntityStrategy OnButtonAdd() => null;
    }
}