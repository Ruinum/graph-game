using Ruinum.ECS.Integration.Entitas;
using Ruinum.ECS.Extensions;
using Entitas;

namespace Ruinum.ECS.Systems.Game
{
    public sealed class TargetEntityListMemberSystem : ReactiveSystemExtended<GameEntity>, IDestroyedListener
    {
        public TargetEntityListMemberSystem(IContext<GameEntity> context) : base(context)
        {
            context.GetGroup(GameMatcher.TargetEntityListMember).OnEntityRemoved += OnMemberRemoved;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TargetEntityListMember);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTargetEntityListMember && entity.hasGameTarget;
        }

        private void OnMemberRemoved(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
        {
            OnDestroyed(entity);
        }

        protected override void Execute(GameEntity e)
        {
            var target = e.gameTarget.Value;
            var entityList = target.hasEntityList ? target.entityList : target.CreateGameEntityListComponent();
            entityList.Value.Add(e);
            target.ReplaceComponent(GameComponentsLookup.EntityList, entityList);
            e.AddDestroyedListener(this);
        }

        public void OnDestroyed(GameEntity entity)
        {
            if (!entity.hasGameTarget)
            {
                return;
            }
            var target = entity.gameTarget.Value;
            if (!target.hasEntityList)
            {
                return;
            }
            var entityListComponent = target.entityList;
            entityListComponent.Value.Remove(entity);
            target.ReplaceEntityList(entityListComponent.Value);
        }
    }
}