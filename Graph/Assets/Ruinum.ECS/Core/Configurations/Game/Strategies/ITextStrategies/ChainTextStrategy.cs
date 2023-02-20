using Ruinum.ECS.Configurations.Game.Strategies;
using Ruinum.ECS.Configurations.Game.Strategies.Texts;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Core.Configurations.Game.Strategies.Texts
{
    public class ChainTextStrategy : TextStrategy
    {
        [AssetSelector(Filter = "t:EntityStrategyConfig", DisableListAddButtonBehaviour = true)] [ListDrawerSettings(CustomAddFunction = nameof(OnButtonAdd))] [LabelWidth(EditorConstants.SmallLabelWidth)] public ITextStrategy[] Data = new ITextStrategy[0];

        public override bool TryGet(GameEntity entity, out string text)
        {
            text = default;

            for (int i = 0, len = Data.Length; i < len; ++i)
            {
                var strategy = Data[i];
                if (!strategy.TryGet(entity, out var value))
                {
                    if(Logging) LogErrorNotFound("TextComponent", (nameof(entity), entity), (nameof(strategy), strategy));
                    return false;
                }

                text += value;
            }
            
            return true;
        }


        private IEntityStrategy OnButtonAdd() => null;
    }
}