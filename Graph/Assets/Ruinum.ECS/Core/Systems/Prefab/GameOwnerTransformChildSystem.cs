using Ruinum.ECS.Extensions;
using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Prefab
{
    public sealed class GameOwnerTransformChildSystem : ReactiveSystemExtended<GameEntity>
    {
        public GameOwnerTransformChildSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameOwnerTransformChild);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGameOwnerTransformChild;
        }

        protected override void Execute(GameEntity e)
        {
            if (e.TryGetTransform(out var transform) && e.GetRootOwnerOrThis().TryGetTransform(out var ownerTransform))
            {
                transform.SetParent(ownerTransform, false);
            }
        }
    }
}