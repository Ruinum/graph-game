using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Targets
{
    public sealed class ChainDepthTargetStrategy : TargetStrategy
    {
        [AssetSelector(Filter = "t:TargetStrategyConfig", DisableListAddButtonBehaviour = true)] [ListDrawerSettings(CustomAddFunction = nameof(OnButtonAdd))][LabelWidth(EditorConstants.SmallLabelWidth)]  public ITargetStrategy[] Strategies;

        public override bool TryGet(GameEntity entity, out GameEntity targetEntity)
        {
            targetEntity = entity;
            for (int i = 0, max = Strategies.Length; i < max; i++)
            {
                if (!Strategies[i].TryGet(targetEntity, out targetEntity))
                {
                    if(Logging) LogErrorNotFound($"{nameof(targetEntity)} in Strategies[{i}]", (nameof(entity), entity));
                    return false;
                }
            }
            return true;
        }

        private ITargetStrategy OnButtonAdd() => null;
    }
}