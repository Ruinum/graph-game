using Ruinum.ECS.Constants;
using Ruinum.ECS.Extensions;
using Sirenix.OdinInspector;

namespace Ruinum.ECS.Configurations.Game.Strategies.Subscribers
{
    public sealed class PublisherToSubscriberCopyStrategy : SubscriberEntityStrategy
    {
        [HideLabel][HideReferenceObjectPicker][LabelWidth(EditorConstants.SmallLabelWidth)] public ComponentsContainer Components = new ComponentsContainer();

        public override bool Process(GameEntity publisher, GameEntity subscriber)
        {
            subscriber.CopyComponents(publisher, Components.ComponentIndexes);
            return true;
        }
    }
}