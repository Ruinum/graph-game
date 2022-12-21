using Ruinum.ECS.Configurations.Game.Strategies.Subscribers;
using Ruinum.ECS.Constants;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers
{
    public sealed class SubscriberChainEntityStrategy : SubscriberEntityStrategy
    {
        [LabelWidth(EditorConstants.SmallLabelWidth)] public ISubscriberEntityStrategy[] Strategies = new SubscriberEntityStrategy[0];

        public override bool Process(GameEntity publisher, GameEntity subscriber)
        {
            for (int i = 0, max = Strategies.Length; i < max; i++)
            {
                if (!Strategies[i].Process(publisher, subscriber))
                {
                    if(Logging) LogError($"Strategies[{i}].Process(publisher, subscriber) failed.");
                    return false;
                }
            }
            return true;
        }
    }
}