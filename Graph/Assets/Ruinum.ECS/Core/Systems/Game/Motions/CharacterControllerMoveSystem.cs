using Entitas;
using Ruinum.ECS.Core.Extensions.Unity;
using Ruinum.ECS.Integration.Entitas;
using UnityEngine;

namespace Ruinum.ECS.Core.Systems
{
    public sealed class CharacterControllerMoveSystem : ReactiveSystemExtended<GameEntity>
    {
        public CharacterControllerMoveSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TransformMoveVector);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCharacterController && entity.hasTransformMoveVector;
        }

        protected override void Execute(GameEntity entity)
        {
            var characterController = entity.characterController.Value;
            if (characterController.IsNull())
            {
                return;
            }
            var resultVector = entity.transformMoveVector.Value;
            if (resultVector == Vector3.zero)
            {
                return;
            }
            characterController.Move(resultVector * Time.deltaTime);

            var position = characterController.transform.position;
            if (!entity.hasTransformPosition || entity.transformPosition.Value != position)
            {
                entity.ReplaceTransformPosition(position);
            }
        }
    }
}