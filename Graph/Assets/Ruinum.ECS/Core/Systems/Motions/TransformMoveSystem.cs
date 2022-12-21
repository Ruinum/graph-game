using Ruinum.ECS.Core.Extensions.Unity;
using Ruinum.ECS.Integration.Entitas;

using Entitas;
using UnityEngine;

namespace Ruinum.ECS.Systems.Game.Motions
{
    public sealed class TransformMoveSystem : ReactiveSystemExtended<GameEntity>
    {
        public TransformMoveSystem(IContext<GameEntity> context) : base(context) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TransformMoveVector);
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.hasCharacterController && entity.hasTransformMoveVector && entity.hasGameObject;
        }

        protected override void Execute(GameEntity entity)
        {
            var gameObject = entity.gameObject.Value;
            
            if (gameObject.IsNull())
            {
                return;            
            }
           
            var transform = gameObject.transform;
            var newPosition = transform.position + entity.transformMoveVector.Value * Time.deltaTime;
            entity.RemoveTransformMoveVector();
            
            if (entity.hasTransformPosition && entity.transformPosition.Value == newPosition)
            {
                return;
            }
            
            transform.position = newPosition;
            entity.ReplaceTransformPosition(newPosition);
        }
    }
}