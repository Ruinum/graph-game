using Ruinum.ECS.Extensions;
using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Core.Extensions.Unity;
using Ruinum.ECS.Integration.Entitas;
using Entitas;

namespace Ruinum.ECS.Systems.Game
{
    public sealed class TransformChildByConfigSystem : ReactiveSystemExtended<GameEntity>
    {
        private readonly IEntityIndexService _entityIndexService;

        public TransformChildByConfigSystem(IContext<GameEntity> context, IEntityIndexService entityIndexService) : base(context)
        {
            _entityIndexService = entityIndexService;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ChildTransformByConfig);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasChildTransformByConfig && entity.hasGameObject && entity.HasRootOwner;
        }

        protected override void Execute(GameEntity entity)
        {
            if (!entity.hasChildTransformByConfig || !entity.TryGetRootOwner(out var rootOwner) || !entity.hasGameObject)
            {
                return;
            }
            if (!_entityIndexService.TryGetTarget(rootOwner, entity.childTransformByConfig.Config, out var target) || !target.hasGameObject)
            {
                UnityEngine.Debug.LogError(_entityIndexService.TryGetTarget(rootOwner, entity.childTransformByConfig.Config, out var target2));
                return;
            }
            var targetGameObject = target.gameObject.Value;
            var childGameObject = entity.gameObject.Value;
            if (targetGameObject.IsNull() || childGameObject.IsNull())
            {
                return;
            }
            childGameObject.transform.SetParent(targetGameObject.transform, false);
        }
    }
}